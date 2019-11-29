using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using PostsImages.Models;
using PostsImages.Services;
using PostsImages.ViewModels;
using Prism.Navigation.Xaml;
using Refit;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Device = Xamarin.Forms.Device;

namespace PostsImages.Views
{
    public partial class InfoOfUserMyView : ContentPage
    {
        public InfoOfUserViewModel ViewModel
        {
            get { return BindingContext as InfoOfUserViewModel; }
        }
        public InfoOfUserMyView()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
             {
                 collectionListview.ItemsSource = ViewModel.collectionInfo;
                 return true;
             });
            
        }
    }
}