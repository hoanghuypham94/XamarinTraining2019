using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace PostsImages.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
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

       

        public MainPageViewModel()
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            UserName = UserInfo.Username;
            Password = UserInfo.Pass;
            //UserName = parameters.GetValue<string>("UserName");
            //Password = parameters.GetValue<string>("Password");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
