using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PostsImages.ViewModels
{
    public class MasterDetailPageMyViewModel : ViewModelBase
    {

        INavigationService _navigationService;
        IPageDialogService _pageDialog;
        IBatteryService _batteryService;

        public MasterDetailPageMyViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }

        private string _userName;
        public string UserName
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

         //{
            
        //}

        //public void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    UserName = parameters.GetValue<string>("UserName");
        //}

        public override void OnNavigatedToAsync(INavigationParameters parameters)
        {
            base.OnNavigatedToAsync(parameters);
        }
    }
}
