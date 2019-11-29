using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace PostsImages.ViewModels
{
    public class GoogleProfilePageViewModel
    {
        public ICommand Comeback { get; set; }
        INavigationService _navigationService;
        public GoogleProfilePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Comeback = new DelegateCommand(async () => await comeback());
        }

        private async Task comeback()
        {
            await _navigationService.NavigateAsync("/LoginMyView");
        }
    }
}
