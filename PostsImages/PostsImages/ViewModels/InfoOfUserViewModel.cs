using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Connectivity;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using PostsImages.Models;
using PostsImages.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Refit;
using Xamarin.Forms;

namespace PostsImages.ViewModels
{
    public class InfoOfUserViewModel : ViewModelBase, INavigationAware
    {
        //public ICommand Loadbtn { get; set; }
        public ICommand BackPageCommand { get; set; }


        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        public InfoOfUserViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            InfoOpacity = 100;
            _navigationService = navigationService;
            BackPageCommand = new DelegateCommand(async () => await Gomain());
            //Loadbtn = new DelegateCommand(async () => await loadbtn());
        }

        ObservableCollection<InfoUser> _collectionList;
        public ObservableCollection<InfoUser> collectionList
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

        //private async Task loadbtn()
        //{
        //    ObservableCollection<InfoUser> users = new ObservableCollection<InfoUser>();
        //    var apiResponse = RestService.For<IUserInfoApi>("https://jsonplaceholder.typicode.com");
        //    var makeUps = await apiResponse.GetMakeUps(username);

        //    users.Add(makeUps[0]);

        //    collectionList = users;
        //}

        private string _userName;
        public string username
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _passWord;
        public string password
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }
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

        
        private int _infoOpacity;
        public int InfoOpacity
        {
            get { return _infoOpacity; }
            set
            {
                if (_infoOpacity == value)
                    return;

                _infoOpacity = value;
                OnPropertyChanged("InfoOpacity");
            }
        }
        //public InfoOfUserViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        //{
        //    _navigationService = navigationService;
        //    _pageDialogService = pageDialogService;

        //    TapBack = new DelegateCommand(async () => await Gohome());
        //    //BackPage = new DelegateCommand(async () => await backpage());

        //}






        //private async Task backpage()
        //{
        //    await _navigationService.NavigateAsync($"/MyMasterDetailPage");
        //}

        private async Task Gomain()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("UserName", username);
            
            await _navigationService.NavigateAsync($"/CustomMasterDetailPage/NavigationPage/MainPageView", navParameters);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
            IsBusy = true;
            //password = "An1234!@#";
            username = parameters.GetValue<string>("UserName");
            //password = parameters.GetValue<string>("Password");
            testinfo();


        }

        int i = 0;
        async void testinfo()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == false)
            {
                //CrossToastPopUp.Current.ShowToastMessage("Không có internet, vui lòng kiểm tra lại đường truyền!", ToastLength.Long);
                if (i == 0)
                {
                    //CrossToastPopUp.Current.ShowToastMessage("Không có internet, vui lòng kiểm tra lại đường truyền!", ToastLength.Long);
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Không có internet, vui lòng kiểm tra lại đường truyền!", "");
                    i = 1;
                }
                testinfo();
            }
            else
            {
                if (i == 1)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Đã kết nối internet thành công!", ToastLength.Long);
                    //        //        //var message = "Đã kết nối internet thành công!";
                    //        //        //DependencyService.Get<IMessage>().Shorttime(message);
                    //        //        //Toast.MakeText(this, "Đã kết nối internet thành công!", ToastLength.Long).Show();
                    //await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã kết nối internet thành công!", "OK");
                    i = 0;
                }
                ObservableCollection<InfoUser> users = new ObservableCollection<InfoUser>();
                //ObservableCollection<UserModel> getusermodel = new ObservableCollection<UserModel>();
                var apiResponse = RestService.For<IUserInfoApi>("https://jsonplaceholder.typicode.com");
                var makeUps = await apiResponse.GetMakeUps(username);

                users.Add(makeUps[0]);
           
                collectionList = users;
                IsBusy = false;
                InfoOpacity = 0;
            }
        }
    }
}
