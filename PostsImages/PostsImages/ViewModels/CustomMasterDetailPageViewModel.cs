using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PostsImages.ViewModels
{
    public class CustomMasterDetailPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand LoguotCommand { get; set; }
        public ICommand MainPageCommand { get; set; }
        public ICommand InfoUserCommand { get; set; }
        public ICommand ShowImageCommand { get; set; }
        public IPageDialogService _pageDialogService;
        INavigationService _navigationService;
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public CustomMasterDetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            LoguotCommand = new DelegateCommand(async () => await loguotCommand(), canExecuteMethod: CanloguotCommand);
            //OnNavigateCommand = new DelegateCommand<string>(NavigateAync);
            MainPageCommand = new DelegateCommand(async () => await mainPageCommand());
            InfoUserCommand = new DelegateCommand(async () => await infoUserCommand());
            ShowImageCommand = new DelegateCommand(async () => await showImageCommand());
        }

        bool isEnable = true;
        private bool CanloguotCommand()
        {
            return isEnable;
        }

        private async Task mainPageCommand()
        {
            var navParameters = new Prism.Navigation.NavigationParameters();
            navParameters.Add("UserName", UserName);
            
            await _navigationService.NavigateAsync($"/CustomMasterDetailPage/NavigationPage/MainPageView", navParameters);

        }

        private async Task showImageCommand()
        {
            var navParameters = new Prism.Navigation.NavigationParameters();
            navParameters.Add("UserName", UserName);
            
            await _navigationService.NavigateAsync($"/CustomMasterDetailPage/NavigationPage/ShowImagesPageMyView", navParameters);
        }

        private async Task infoUserCommand()
        {
            var navParameters = new Prism.Navigation.NavigationParameters();
            navParameters.Add("UserName", UserName);
            
            await _navigationService.NavigateAsync($"/CustomMasterDetailPage/NavigationPage/InfoOfUserMyView", navParameters);
        }

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
            UserName = parameters.GetValue<string>("UserName");
        }




        //    UserName = parameters.GetValue<string>("UserName");
        //    Password = parameters.GetValue<string>("Password");



    }
}
