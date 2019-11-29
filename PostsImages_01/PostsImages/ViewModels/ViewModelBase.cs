using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;


namespace PostsImages.ViewModels
{
    public class ViewModelBase : BindableBase, IDestructible, IApplicationLifecycleAware, INotifyPropertyChanged
    {

        protected INavigationService _navigationService { get; set; }
        protected IPageDialogService _pageDialogService { get; set; }

        private string _title;
        private INavigationService navigationService;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigationService"></param>
        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {

            this._navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }

        public ViewModelBase(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        /// <summary>
        /// OnNavigatedFrom
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedFromAsync(INavigationParameters parameters)
        {
           
        }

        /// <summary>
        /// OnNavigatedTo
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedToAsync(INavigationParameters parameters)
        {

        }

        /// <summary>
        /// OnNavigatingTo
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }
        /// <summary>
        /// Destroy this instance.
        /// </summary>
        public virtual void Destroy()
        {


        }

        /// <summary>
        /// Cans the executable.
        /// </summary>
        /// <param name="running">If set to <c>true</c> running.</param>
        /// <param name="execute">Execute.</param>
        public void CanExecutable(bool running, Action execute)
        {
            if (running)
            {
                return;
            }
            execute.Invoke();
        }

        public virtual void OnResume()
        {

        }

        public virtual void OnSleep()
        {

        }

        public virtual void CancelTasksOnDisappearing()
        {

        }

        public async Task NavigateAsyncBaseAsync(string pageTarget, INavigationParameters parameters = null)
        {
            await _navigationService.NavigateAsync(pageTarget, parameters);
            //LogCommon.LogDev($"Action : NavigateAsync {pageTarget}");
        }


        public async Task GoBackBase(INavigationParameters parameters = null)
        {
            await _navigationService.GoBackAsync(parameters);
        }

        public async Task GoBackRootBase(INavigationParameters parameters = null)
        {
            await _navigationService.GoBackToRootAsync(parameters);
        }

       

    }
}
