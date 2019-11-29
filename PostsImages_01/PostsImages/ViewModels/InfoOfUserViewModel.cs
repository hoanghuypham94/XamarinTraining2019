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


        INavigationService _navigationsService;
        IPageDialogService _pageDialogsService;

        public InfoOfUserViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            InfoOpacity = 100;
            _navigationsService = navigationService;
            BackPageCommand = new DelegateCommand(async () => await Gomain());
            //Loadbtn = new DelegateCommand(async () => await loadbtn());
        }

        

        ObservableCollection<InfoUser> _collectionInfo;
        public ObservableCollection<InfoUser> collectionInfo
        {
            get
            {
                return _collectionInfo;
            }
            set
            {
                if (_collectionInfo != value)
                {
                    _collectionInfo = value;
                }
            }
        }

       

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
            
            username = UserInfo.Username;
            password = UserInfo.Pass;
            testinfo();


        }

        int test = 0;
        async void testinfo()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == false)
            {
                
                if (test == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Không có internet, vui lòng kiểm tra lại đường truyền!", "");
                    test = 1;
                }
                testinfo();
            }
            else
            {
                if (test == 1)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Đã kết nối internet thành công!", ToastLength.Long);

                    test = 0;
                }
                ObservableCollection<InfoUser> users = new ObservableCollection<InfoUser>();
               
                var apiResponse = RestService.For<IUserInfoApi>("https://jsonplaceholder.typicode.com");
                var makeUps = await apiResponse.GetMakeUps(username);

                users.Add(makeUps[0]);
                var user = users[0] as InfoUser;
                user.password = UserInfo.Pass;
                collectionInfo = users;
                IsBusy = false;
                InfoOpacity = 0;
            }
        }
    }
}
