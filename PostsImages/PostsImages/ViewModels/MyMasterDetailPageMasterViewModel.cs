using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace PostsImages.ViewModels
{
    public class MyMasterDetailPageMasterViewModel : BindableBase, INotifyPropertyChanged, INavigatedAware
    {

        //public string SelectedItemText { get; private set; }
        //public ICommand MenuItemCommand { get; set; }
        public ICommand LoguotCommand { get; set; }
        
        INavigationService _navigationService;
        //public ObservableCollection<MyMasterDetailPageMenuItem> MenuItems { get; set; }
        


        public MyMasterDetailPageMasterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoguotCommand = new DelegateCommand(async () => await logoutcommand());
            
            //MenuItems = new ObservableCollection<MyMasterDetailPageMenuItem>
            //{
            //    new MyMasterDetailPageMenuItem { Id = 0, Title = "Thông tin cá nhân" },
            //    new MyMasterDetailPageMenuItem { Id = 1, Title = "Duyệt hình ảnh" },
            //};
            //MenuItemCommand = new Command<MyMasterDetailPageMenuItem>(ClickItemCommand);

        }

        //private async Task logoutcommand()
        //{
        //    await _navigationService.NavigateAsync($"/LoginMyView");
        //}

        //private  void ClickItemCommand(MyMasterDetailPageMenuItem e)
        //{
        //    var item = e ;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    switch (item.Id)
        //    {
        //        case 0:
        //             _navigationService.NavigateAsync($"InfoOfUserMyView");
        //            //Navigation.PushAsync(new InfoOfUserMyView());
        //            //Detail = new NavigationPage(new InfoOfUserMyView());
        //            //IsPresented = false;
        //            break;
        //        case 1:
        //             _navigationService.NavigateAsync($"ShowImagesPageMyView");
        //            //Detail = new NavigationPage(new ShowImagesPageMyView());
        //            //IsPresented = false;
        //            break;
        //    }
        //}
       

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public void OnNavigatedFromAsync(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            UserName = parameters.GetValue<string>("UserName");
        }

        

        private async Task logoutcommand()
        {
            await _navigationService.NavigateAsync($"LoginMyView");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
