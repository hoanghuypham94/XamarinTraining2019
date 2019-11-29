using System;
using System.ComponentModel;
using System.Json;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.FacebookClient;
using PostsImages.Models;
using PostsImages.Services;
using PostsImages.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using Xamarin.Auth;
using Xamarin.Forms;


namespace PostsImages.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ICommand SelectedItemCommand { get; private set; }
        public ICommand OnLogin { get; set; }
        public ICommand LoginGoogle { get; set; }
        public ICommand OnLoginFB { get; set; }

        INavigationService _navigationsService;
        IPageDialogService _pageDialogsService;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _imageAvatar;
        public string ImageAvatar
        {
            get { return _imageAvatar; }
            set { SetProperty(ref _imageAvatar, value); }
        }

        private string _passWord;
        public string Password
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }
        }

        public LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            UserName = "Antonette";
            Password = "An1234!@#";

            _navigationsService = navigationService;
            _pageDialogsService = pageDialogService;

            OnLoginFB = new DelegateCommand(async () => await onloginfb());
            OnLogin = new DelegateCommand(async () => await onlogin());
            LoginGoogle = new DelegateCommand(async () => await onlogingl());

            TestLogin();
            //UserChangedCommand = new Command(UserChanged);
            //SelectedItemCommand = new DelegateCommand(UserChanged);
            
        }




        private bool _isError;
        public bool IsError
        {
            get { return _isError; }
            set
            {
                if (_isError == value)
                    return;

                _isError = value;
                OnPropertyChanged("IsError");
            }
        }


        private bool _isLogin;
        public bool IsLogin
        {
            get { return _isLogin; }
            set
            {
                if (_isLogin == value)
                    return;

                _isLogin = value;
                OnPropertyChanged("IsLogin");
            }
        }

        int passnumber;
        int usernumber;

        private DelegateCommand<string> _textChangedCommand;
        public DelegateCommand<string> TextChangedCommand =>
            _textChangedCommand ?? (_textChangedCommand = new DelegateCommand<string>(TextChanged));

        private void TextChanged(string p)
        {

            TestLogin();

        }

        void TestLogin()
        {
            passnumber = Password.Length;
            usernumber = UserName.Length;

            // match is check enter password have number, words and words special
            bool match = Regex.IsMatch(Password,
                @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"); 

            if (usernumber >= 8 && passnumber >= 8 && match == true) // check lenght username and password >= 8 words.
            {
                IsError = false;
                IsLogin = true;
            }
            else
            {
                IsError = true;
                IsLogin = false;
            }
        }


        private async Task onlogin()
        {
            UserInfo.Username = UserName;
            UserInfo.Pass = Password;

            await _navigationsService.NavigateAsync(
                        $"/CustomMasterDetailPage/NavigationPage/MainPageView",
                        useModalNavigation: true
                  );
        }

        //private async Task onloginfb()
        //{
        //    await _navigationsService.NavigateAsync("NavigationPage/FacebookProfilePage");
        //}


        private async Task onlogingl()
        {
            await _navigationsService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(GoogleProfilePage));
        }


        
        private async Task onloginfb()
        {

            
            await _navigationService.NavigateAsync(nameof(NavigationPage)+ "/" + nameof(FacebookProfilePage));

        }

        
    }

}
