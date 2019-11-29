using System;
using System.Collections.Generic;
using System.IO;
using PostsImages.Models;
using PostsImages.Services;
using Xamarin.Forms;

namespace PostsImages.Views
{
    public partial class MainPageView : ContentPage
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
                
            }

           (sender as Button).IsEnabled = true;
        }
    }
}
