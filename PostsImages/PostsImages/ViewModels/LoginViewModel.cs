using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using PostsImages.Models;
using PostsImages.Services;
using PostsImages.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using Xamarin.Forms;


namespace PostsImages.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public ICommand OnLogin { get; set; }
        public ICommand LoginGoogle { get; set; }
        public ICommand LoginFacebook { get; set; }


        //private DelegateCommand _navigateCommand;
        //private readonly INavigationService _navigationService;


        //public DelegateCommand OnLogin =>
        //    _navigateCommand ?? (_navigateCommand = new DelegateCommand(on_login));

        //async void on_login()
        //{
        //    var p = new NavigationParameters();
        //    p.Add("UserName", "Antonette");
        //    await _navigationService.NavigateAsync($"/MyMasterDetailPage",p);
        //}

        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _passWord;
        public string Password
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }
        }
        public LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService):base(navigationService,pageDialogService)
        {
            UserName = "Antonette";
            Password = "An1234!@#";
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            LoginFacebook = new DelegateCommand(async () => await onloginfb());
            OnLogin = new DelegateCommand(async () => await onlogin());
            LoginGoogle = new DelegateCommand(async () => await onlogingl());

        }

        

        private async Task onlogin()
        {
            var navParameters = new Prism.Navigation.NavigationParameters();
            
            navParameters.Add("UserName", UserName);
            
            await _navigationService.NavigateAsync(
                        $"/CustomMasterDetailPage/NavigationPage/MainPageView",
                        navParameters
                  );
            
        }

        private async Task onloginfb()
        {
            await _navigationService.NavigateAsync("NavigationPage/FacebookProfilePage");
        }


        private async Task onlogingl()
        {
            await _navigationService.NavigateAsync("NavigationPage/GoogleProfilePage");
        }




        //bool _loginIsVisible;
        //public bool LoginIsVisible
        //{
        //    get { return _loginIsVisible; }
        //    set
        //    {
        //        checkusername();
        //        _loginIsVisible = value;
        //        OnPropertyChanged(nameof(LoginIsVisible));
        //    }
        //}

        //private void checkusername()
        //{
        //    if (UserName.Length >= 8)
        //        _loginIsVisible = false;
        //}

        //private async Task onlogin()
        //{
        //    var contact = new UserModel()
        //    {
        //        UserName = UserName
        //    };
        //    var secondPage = new MyMasterDetailPage();
        //    secondPage.BindingContext = contact;
        //    await _navigationService.NavigateAsync($"/MyMasterDetailPage");

        //}
    }
}
