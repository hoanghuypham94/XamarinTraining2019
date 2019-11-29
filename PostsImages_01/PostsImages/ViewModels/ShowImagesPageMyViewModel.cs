using System;
using Plugin.Connectivity;
using System.Collections.ObjectModel;

using System.Threading.Tasks;
using System.Windows.Input;
using PostsImages.Models;
using PostsImages.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Refit;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using PostsImages.Views;
using Prism.Navigation.Xaml;
using System.Linq;

namespace PostsImages.ViewModels
{
    
    public class ShowImagesPageMyViewModel : ViewModelBase, INavigationAware
    {
        
        ObservableCollection<Photoss> photos = new ObservableCollection<Photoss>();
        INavigationService _navigationService;
        IPageDialogService _pageDialogsService;
        
       
        public ICommand TapShow { get; set; }
        
        public ShowImagesPageMyViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
           
            _navigationService = navigationService;
           
            
        }

        



      

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _numberShow;
        public string NumberShow
        {
            get { return _numberShow; }
            set { SetProperty(ref _numberShow, value); }
        }


        private string _collectSelectChanged;
        public string CollectSelectChanged
        {
            get
            {
                return _collectSelectChanged;
            }
            set
            {
                _collectSelectChanged = value;
                RaisePropertyChanged();
            }
        }


        ObservableCollection<Photoss> _collectionList;
        public ObservableCollection<Photoss> collectionList
        {
            get
            {
                return _collectionList;
            }
            set
            {
                if (_collectionList != value)
                {
                    _collectionList = value;
                }
            }
        }
       

       

        private bool _isBusy;
        public bool IsBusy 
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }


        private Photoss selectedMenuItem;
        public Photoss SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }

        public ICommand ActivityWasSelected => new Command<object>(async selectionChangedCommandParameter => 
        {
           
            var navParameters = new Prism.Navigation.NavigationParameters();
            navParameters.Add("Id", SelectedMenuItem.id);
           
            await base._navigationService.NavigateAsync( nameof(NavigationPage)
                + "/" + nameof(PostsImages.Views.DetailImageMyView), (INavigationParameters)navParameters);

        });

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
            
                 GetPhotos();
          
           
        }

        int test = 0;
        async void GetPhotos()
        {
            IsBusy = true;

            // check if not internet => isConnected's value is false else => isConnected's value is true
            var isConnected = CrossConnectivity.Current.IsConnected; 
            if (isConnected == false)
            {
                if (test == 0)
                {
                    var res = await Application.Current.MainPage.DisplayAlert
                            ("Thông báo", "Không có internet, vui lòng kiểm tra lại đường truyền!, " +
                            "bạn có muốn tải lại không?", "OK", "Cancel");

                    if (res == true) // if click Ok => res'value is true => reload data.
                        GetPhotos();
                    test = 1;
                }
            }
            else
            {
                if (test == 1)
                {
                    CrossToastPopUp.Current.ShowToastMessage
                             ("Đã kết nối internet thành công!", ToastLength.Long);
                    test = 0;

                }
                    ObservableCollection<InfoUser> users = new ObservableCollection<InfoUser>();

                    ObservableCollection<Albums> album = new ObservableCollection<Albums>();

                    var apiResponse = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");


                
                var makeUps = await apiResponse.GetPhotosid();
                    for (int Number = 0; Number < 50; Number++) // Number is order number of each image.
                {
                        photos.Add(makeUps[Number]); // Get 50 photos from https://jsonplaceholder.typicode.com/photos
                        var photo = photos[Number] as Photoss; 

                        var makeUpsalbum = await apiResponse.GetMakeUpsalbum("" + photo.albumId);
                        album.Add(makeUpsalbum[0]);

                        var getalbum = album[Number] as Albums;

                        // Get name user from https://jsonplaceholder.typicode.com/ugetalbum.userId?id=getalbum.userId
                        var makeUpsuserid = await apiResponse.GetMakeUpsid("" + getalbum.userId); 
                        users.Add(makeUpsuserid[0]);

                        var getuser = users[Number] as InfoUser;

                        photo.titlealbum = getalbum.title; // set value of album's title to photos list
                        photo.name = getuser.name; // set value of user's name to photos list
                    }

                    collectionList = photos;
                   
                    IsBusy = false; 
               
            }  
        }
    }
}
