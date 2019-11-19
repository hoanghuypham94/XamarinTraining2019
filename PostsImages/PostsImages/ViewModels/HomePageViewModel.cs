using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PostsImages.ViewModels
{
    public class HomePageViewModel : BindableBase
    {

        INavigationService _navigationService;
        IPageDialogService _pageDialog;
        IBatteryService _batteryService;
        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private string _userName;
        public string name
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public void GetBatteryStatus()
        {
            var batteryStatus = _batteryService.GetBatteryStatus();
            _pageDialog.DisplayAlertAsync("Battery Status", batteryStatus, "Ok");
            _navigationService.GoBackAsync();
        }


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //_navigationService.GoBackAsync();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("name"))
            {
                name = parameters.GetValue<string>("name");
            }
        }
    }
}
