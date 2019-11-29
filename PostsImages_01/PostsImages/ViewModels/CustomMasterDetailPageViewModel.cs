using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PostsImages.Models;
using PostsImages.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace PostsImages.ViewModels
{
    public class CustomMasterDetailPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand NavigateCommand { get; private set; }
        public DelegateCommand LoguotCommand { get; set; }
        public ICommand MainPageCommand { get; set; }
        public ICommand InfoUserCommand { get; set; }
        public ICommand ShowImageCommand { get; set; }
        public IPageDialogService _pageDialogService;
        INavigationService _navigationService;
        public DelegateCommand<string> OnNavigateCommand { get; set; }

        public ObservableCollection<HomePageMenuItem> MenuItems { get; set; }

        private HomePageMenuItem selectedMenuItem;
        public HomePageMenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }

       

        public CustomMasterDetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            ImageAvatar = "avatar.png";
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            LoguotCommand = new DelegateCommand(async () => await loguotCommand(), canExecuteMethod: CanloguotCommand);
            //OnNavigateCommand = new DelegateCommand<string>(NavigateAync);
            //MainPageCommand = new DelegateCommand(async () => await mainPageCommand());
            //InfoUserCommand = new DelegateCommand(async () => await infoUserCommand());
            //ShowImageCommand = new DelegateCommand(async () => await showImageCommand());
            MenuItems = new ObservableCollection<HomePageMenuItem>(new[]
           {
                     new HomePageMenuItem { Id = 0, TitleMenu = "Thông tin cá nhân", PageName = nameof(ShowImagesPageMyView) },
                     new HomePageMenuItem { Id = 1, TitleMenu = "Duyệt hình ảnh", PageName = nameof(InfoOfUserMyView) },

             });
            NavigateCommand = new DelegateCommand(Navigate);
        }

        async void Navigate()
        {
           
            
            switch (SelectedMenuItem.Id)
            {
                case 0:
                   
                    await _navigationService.NavigateAsync("/" + nameof(CustomMasterDetailPage)
                        + "/" + nameof(NavigationPage) + "/" + nameof(InfoOfUserMyView));
                    break;
                case 1:
                   
                    
                    await _navigationService.NavigateAsync("/" + nameof(CustomMasterDetailPage)
                        + "/" + nameof(NavigationPage) + "/" + nameof(ShowImagesPageMyView));
                    break;

                default:
                    break;
            }
           
        }



        bool isEnable = true;
        private bool CanloguotCommand()
        {
            return isEnable;
        }

        //private async Task mainPageCommand()
        //{
        //    var navParameters = new Prism.Navigation.NavigationParameters();
        //    navParameters.Add("UserName", UserName);

        //    await _navigationService.NavigateAsync($"/CustomMasterDetailPage/NavigationPage/MainPageView", navParameters);

        //}

        //private async Task showImageCommand()
        //{
        //    var navParameters = new Prism.Navigation.NavigationParameters();
        //    navParameters.Add("UserName", UserName);

        //    await _navigationService.NavigateAsync($"/CustomMasterDetailPage/NavigationPage/ShowImagesPageMyView", navParameters);
            
        //}

        //private async Task infoUserCommand()
        //{
        //    var navParameters = new Prism.Navigation.NavigationParameters();
        //    navParameters.Add("UserName", UserName);

        //    await _navigationService.NavigateAsync($"/CustomMasterDetailPage/NavigationPage/InfoOfUserMyView", navParameters);
        //}

        private string _numberShow;
        public string NumberShow
        {
            get { return _numberShow; }
            set { SetProperty(ref _numberShow, value); }
        }

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
        //async void NavigateAync(string page)
        //{
        //    await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        //}
        int i = 0;
        private async Task loguotCommand()
        {
           
                await _navigationService.NavigateAsync($"/LoginMyView");
                
            
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            UserName = UserInfo.Username;
            
        }




        //    UserName = parameters.GetValue<string>("UserName");
        //    Password = parameters.GetValue<string>("Password");



    }
}
