using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using PostsImages.Models;
using PostsImages.Services;
using PostsImages.ViewModels;
using Prism.AppModel;
using Prism.Navigation;
using Refit;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PostsImages.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowImagesPageMyView : ContentPage
    {
        public ShowImagesPageMyView()
        { 
            InitializeComponent();
        }
    }
}
