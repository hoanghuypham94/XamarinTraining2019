using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PostsImages.Models;
using PostsImages.Services;
using PostsImages.Views;
using Prism.Commands;
using Prism.Navigation;
using Refit;
using Xamarin.Forms;

namespace PostsImages.ViewModels
{
    public class DetailImageMyViewModel : ViewModelBase, INavigationAware
    {
        
        INavigationService _navigationsService;
        public DetailImageMyViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationsService = navigationService;
           
        }

        

        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        ObservableCollection<Photoss> _collectionListDetail;
        public ObservableCollection<Photoss> collectionListDetail
        {
            get
            {
                return _collectionListDetail;
            }
            set
            {
                if (_collectionListDetail != value)
                {
                    _collectionListDetail = value;
                }
            }
        }

       

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Id = parameters.GetValue<string>("Id");
            DetailPhotos();
        }

            async void DetailPhotos()
        {
            ObservableCollection<InfoUser> users = new ObservableCollection<InfoUser>();
            var apiResponseuser = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");

            ObservableCollection<Albums> album = new ObservableCollection<Albums>();
            var apiResponsealbum = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");

            ObservableCollection<Photoss> detailphotos = new ObservableCollection<Photoss>();
            var apiResponse = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");

            
            int number = Convert.ToInt32(Id);
            var makeUpsDetail = await apiResponse.GetPhotosid();

                detailphotos.Add(makeUpsDetail[number-1]);
                var photo = detailphotos[0] as Photoss;

                var makeUpsalbum = await apiResponse.GetMakeUpsalbum("" + photo.albumId);
                album.Add(makeUpsalbum[0]);

                var getalbum = album[0] as Albums;

                var makeUpsuserid = await apiResponse.GetMakeUpsid("" + getalbum.userId);
                users.Add(makeUpsuserid[0]);

                var getuser = users[0] as InfoUser;

                photo.titlealbum = getalbum.title;
                photo.name = getuser.name;
            
            collectionListDetail = detailphotos;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
