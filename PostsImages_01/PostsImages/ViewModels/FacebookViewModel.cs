using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using PostsImages.Models;
using PostsImages.Services;
using PostsImages.Views;
using Prism.Commands;
using Prism.Navigation;

namespace PostsImages.ViewModels
{
    public class FacebookViewModel : INotifyPropertyChanged
    {
        public ICommand BackPageCommand { get; set; }
        private FacebookProfile _facebookProfile;
        INavigationService _inavigationsService;

        public FacebookProfile FacebookProfile
        {
            get { return _facebookProfile; }
            set
            {
                _facebookProfile = value;
                OnPropertyChanged();
            }
        }

        public FacebookViewModel(INavigationService inavigationService)
        {
            _inavigationsService = inavigationService;
            BackPageCommand = new DelegateCommand(async () => await Gomain());
        }

        private async Task Gomain()
        {
            await _inavigationsService.NavigateAsync("/" + nameof(LoginMyView));
        }

        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookServices = new FacebookServices();

            FacebookProfile = await facebookServices.GetFacebookProfileAsync(accessToken);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
