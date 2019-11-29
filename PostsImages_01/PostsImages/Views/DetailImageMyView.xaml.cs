using System;
using System.Collections.Generic;
using PostsImages.ViewModels;
using Xamarin.Forms;

namespace PostsImages.Views
{
    public partial class DetailImageMyView : ContentPage
    {
        public DetailImageMyViewModel ViewModel
        {
            get { return BindingContext as DetailImageMyViewModel; }
        }
        public DetailImageMyView()
        {
            InitializeComponent();
           
                //CollectionListDetail.ItemsSource = ViewModel.collectionListDetail;
                
           
        }
    }
}
