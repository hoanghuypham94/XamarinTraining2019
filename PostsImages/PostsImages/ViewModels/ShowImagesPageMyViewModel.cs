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

namespace PostsImages.ViewModels
{
    //[XamlComilation(XamlCompilationOptions.Comile)]
    public class ShowImagesPageMyViewModel : ViewModelBase, INavigationAware
    {
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        // public CollectionView<Photos> CollectionList;
        public ICommand TapShow { get; set; }
        //public ICommand CollectionviewCommand { get; set; }
        //CollectionviewCommand
        //  //  private ICommand
        //private ICommand _collectionviewcommand;
        //public ICommand Collectionviewcommand =>
        //    _collectionviewcommand ?? (_collectionviewcommand = new DelegateCommand<object>((para) =>
        //    {

        //        var t = 5;

        //    }));
        public ShowImagesPageMyViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            //CheckConnectivity();
            //GetData();
            _navigationService = navigationService;
            //CollectionviewCommand = new DelegateCommand(async () => await Collectionview_Command());
            //TapShow = new Command(async () => await (GetData()));
           
        }

        //private async Task Collectionview_Command()
        //{
        //    await _navigationService.NavigateAsync($"/DetailImageMyView");
        //}

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }


        private string _SelectedItem;
        public string CollectionviewCommand
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                RaisePropertyChanged();
            }
        }
        ObservableCollection<Photos> _collectionList;
        public ObservableCollection<Photos> collectionList
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

        //async Task GetData()
        //{

        //    ObservableCollection<Photos> photos = new ObservableCollection<Photos>();
        //    var apiResponse = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");
        //    var makeUps = await apiResponse.GetMakeUps();
        //    for (int i = 0; i < 50; i++)
        //    {



        //        photos.Add(makeUps[i]);

        //    }
        //    collectionList = photos;

        //    //CollectionList = new ObservableCollection<Photos>(photos);
        //    //CollectionList.ItemsSource = photos;
        //}

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
            IsBusy = true;
            GetPhotos();
            
        }
        int j = 0;
        async void GetPhotos()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == false)
            {
                //CrossToastPopUp.Current.ShowToastMessage("Không có internet, vui lòng kiểm tra lại đường truyền!", ToastLength.Long);
                if (j == 0)
                {
                    //CrossToastPopUp.Current.ShowToastMessage("Không có internet, vui lòng kiểm tra lại đường truyền!", ToastLength.Long);
                    var res = await Application.Current.MainPage.DisplayAlert
                        ("Thông báo", "Không có internet, vui lòng kiểm tra lại đường truyền!, " +
                        "bạn có muốn tải lại không?", "OK","Cancel");
                                j = 1;
                    if(res == true)
                    {
                        GetPhotos();
                    }
                    else { }
                }
                
            }
            else
            {
                if (j == 1)
                {
                    CrossToastPopUp.Current.ShowToastMessage
                        ("Đã kết nối internet thành công!", ToastLength.Long);
                    j = 0;
                }  
                        ObservableCollection<InfoUser> users = new ObservableCollection<InfoUser>();
                        var apiResponseuser = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");
                       
                        ObservableCollection<Albums> album = new ObservableCollection<Albums>();
                        var apiResponsealbum = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");

                        ObservableCollection<Photos> photos = new ObservableCollection<Photos>();
                        var apiResponse = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");
                        var makeUps = await apiResponse.GetMakeUpsid();
                        for (int i = 0; i <= 50; i++)
                        {
                            photos.Add(makeUps[i]);
                            var photo = photos[i] as Photos;

                            var makeUpsalbum = await apiResponse.GetMakeUpsalbum("" + photo.albumId);
                            album.Add(makeUpsalbum[0]);

                            var getalbum = album[i] as Albums;

                            var makeUpsuserid = await apiResponse.GetMakeUpsid("" + getalbum.userId);
                            users.Add(makeUpsuserid[0]);

                            var getuser = users[i] as InfoUser;

                            photo.titlealbum = getalbum.title;
                            photo.name = getuser.name;


                }
                collectionList = photos;
                IsBusy = false;
            }

            
        }


        //private async void CheckConnectivity()
        //{
        //    try
        //    {
        //        var isConnected = CrossConnectivity.Current.IsConnected;
        //        if (isConnected == false)
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Thông báo", "Không có internet, vui lòng kiểm tra lại đường truyền!", "OK");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
           

        //    //var isConnected = CrossConnectivity.Current.IsConnected;
        //    //if (isConnected == true)
        //    //{
        //    //    await Application.Current.MainPage.DisplayAlert("Thông báo", "Internet đã được kết nối!", "OK");
        //    //    //await DisplayAlert("Thông báo", "Internet đã được kết nối!", "OK");
        //    //}
        //    //else
        //    //    await Application.Current.MainPage.DisplayAlert("Thông báo", "Không có, vui lòng kiểm tra lại đường truyền!", "OK");
        //    ////await DisplayAlert("Thông báo", "Không có, vui lòng kiểm tra lại đường truyền!", "OK");

        //}
        //public async void OnGetPhotos()
        //{
        //    var collectionView = new CollectionView();
        //    //var collectionView = this.FindByName<CollectionView>("collectionList");
        //    List<Photos> photos = new List<Photos>();
        //    var apiResponse = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");

        //    for (int i = 1; i < 50; i++)
        //    {

        //        var makeUps = await apiResponse.GetMakeUps("" + i);

        //        photos.Add(makeUps[0]);

        //    }
        //    collectionView.ItemsSource = photos;
        //}
    }
}
