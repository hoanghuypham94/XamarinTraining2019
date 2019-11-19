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
        
            public ShowImagesPageMyViewModel ViewModel
        {
            get { return BindingContext as ShowImagesPageMyViewModel; }
        }
        public ShowImagesPageMyView()
        {
            //CheckConnectivity();
            InitializeComponent();

            //  collectionList.SelectionChanged += CollectionList_SelectionChanged;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // Do something
                collectionListview.ItemsSource = ViewModel.collectionList;
                return true; // True = Repeat again, False = Stop the timer
            });
            collectionListview.SelectionChanged += collectionListview_SelectionChanged;
        }

        private async void collectionListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var photos = e.CurrentSelection;

            for (int i =0; i < photos.Count;i++)
            {
                var photo = photos[i] as Photos;
                
                var contact = new DetailImageModel()
                {
                    Title = photo.title,
                    Image = photo.url,
                    AlbumId = photo.albumId,
                    Id = photo.id,
                    Name = photo.name,
                    TitleAlbum = photo.titlealbum
                    
                };
                var secondPage = new DetailImageMyView();
                secondPage.BindingContext = contact;
                Navigation.PushAsync(secondPage);
            }
        }

        private void CollectionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //private async void CheckConnectivity()
        //{
           
        //    var isConnected = CrossConnectivity.Current.IsConnected;
        //    if(isConnected == true)
        //    {
        //        await DisplayAlert("Thông báo", "Internet đã được kết nối!", "OK");
        //    }
        //    else
        //        await DisplayAlert("Thông báo", "Không có, vui lòng kiểm tra lại đường truyền!", "OK");

        //}
        
        //private void showitem(object sender, EventArgs e)
        //{
        //    collectionListview.ItemsSource = ViewModel.collectionList;
        //}

        //private async void OnGetPhotosClicked(object sender, EventArgs e)
        //{
            

        //    List<Photos> photos = new List<Photos>();
        //    //List<InfoUser> users = new List<InfoUser>();
        //    var apiResponsephoto = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");
        //    //var apiResponseuser = RestService.For<IPhotosApi>("https://jsonplaceholder.typicode.com");
        //    for (int i = 1; i < 50; i++)
        //    {

        //        var makephoto = await apiResponsephoto.GetMakeUps("" + i);
                
        //        //var makeuser = await apiResponseuser.GetMakeUpsphoto("" + i);
        //        //users.Add(makeuser[0]);
        //        photos.Add(makephoto[0]);
        //        //photos[1].name = "Huy"; 

        //    }
        //    collectionList.ItemsSource = photos;
        //    //collectionList.ItemsSource = users;
        //    //var name = this.FindByName<Label>("Name");
        //    //if (name.Text == "" + 2)
        //    //{
        //    //    name.Text = "Huy";
        //    //}
        //}

        //var name = this.FindByName<Entry>("UserName");
        //    var pass = this.FindByName<Entry>("Password");
        //    var uri = $"https://jsonplaceholder.typicode.com/users?username=Antonette";

        //    HttpClient client = new HttpClient();
        //    var response = await client.GetStringAsync(uri);
        //    var data = JsonConvert.DeserializeObject<InfoUser>(response);



        //    var contact = new UserModel()
        //    {
        //        UserName = name.Text,
        //        //Password = "" + pass.Text,
        //        Id = data.id,
        //        Name = data.name,
        //        Email = data.email,
        //        Phone = data.phone,
        //        Address = data.address.street,
        //        City = data.address.city,
        //    };

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    List<Photos> listItems = new List<Photos>();
        //    Photos listItem = new Photos() { title = "iPhone", id = 2, albumId = 12, Percentage = "50%" };
        //    Photos listItem1 = new Photos() { title = "iPhone", id = 3, albumId = 123, Percentage = "50%" };
        //    Photos listItem2 = new Photos() { title = "iPhone", id = 4, albumId = 1234, Percentage = "50%" };
        //    Photos listItem3 = new Photos() { title = "iPhone", id = 5, albumId = 12345, Percentage = "50%" };
        //    listItems.Add(listItem);
        //    listItems.Add(listItem1);
        //    listItems.Add(listItem2);
        //    listItems.Add(listItem3);
        //    collectionList.ItemsSource = listItems;

        //}
    }
}
