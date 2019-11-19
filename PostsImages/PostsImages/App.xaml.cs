using System;
using PostsImages.ViewModels;
using PostsImages.Views;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostsImages
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new System.Uri("/LoginMyView", System.UriKind.Absolute));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginMyView, LoginViewModel>();
            //containerRegistry.RegisterForNavigation<MyMasterDetailPage, MasterDetailPageMyViewModel>();
            containerRegistry.RegisterForNavigation<InfoOfUserMyView, InfoOfUserViewModel>();
            containerRegistry.RegisterForNavigation<ShowImagesPageMyView, ShowImagesPageMyViewModel>();
            //containerRegistry.RegisterForNavigation<MyMasterDetailPageMaster, MyMasterDetailPageMasterViewModel>();
            containerRegistry.RegisterForNavigation<GoogleProfilePage, GoogleProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<FacebookProfilePage, FacebookProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<CustomMasterDetailPage, CustomMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPageView, MainPageViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type authenticationModuleType = typeof(AuthenticationModule.AuthenticationModule);
            moduleCatalog.AddModule(
             new ModuleInfo(authenticationModuleType)
             {
                 ModuleName = authenticationModuleType.Name,
                 InitializationMode = InitializationMode.OnDemand
             });
        }

    }
}
