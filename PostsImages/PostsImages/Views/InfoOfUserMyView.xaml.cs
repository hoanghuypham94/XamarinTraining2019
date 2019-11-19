using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PostsImages.Models;
using PostsImages.Services;
using PostsImages.ViewModels;
using Prism.Navigation.Xaml;
using Refit;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

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
            //collectionListview.ItemsSource = ViewModel.collectionList;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // Do something
                collectionListview.ItemsSource = ViewModel.collectionList;
                return true; // True = Repeat again, False = Stop the timer
            });
        }



        //async void ChangeUserName(object sender, TextChangedEventArgs e)
        //{
        //    //List<InfoUser> users = new List<InfoUser>();
        //    var enty = (Entry)sender;
        //    var apiResponse = RestService.For<IUserInfoApi>("https://jsonplaceholder.typicode.com");
        //    var makeUps = await apiResponse.GetMakeUps(enty.Text);
        //    //users.Add(makeUps[0]);
        //    //users = makeUps;
        //    //---------
        //    collectionListview.ItemsSource = makeUps;

        //}



        //void Loadbtn(object sender, EventArgs e)
        //{
        //    collectionListview.ItemsSource = ViewModel.collectionList;
        //    //var apiResponse = RestService.For<IUserInfoApi>("https://jsonplaceholder.typicode.com");
        //    //var makeUps = await apiResponse.GetMakeUps("Antonette");

        //    //collectionListview.ItemsSource = makeUps;

        //}



        //private void BackPage(object sender, EventArgs e)
        //{
        //    var secondPage = new MainPageView();
        //    Application.Current.MainPage = new NavigationPage(secondPage);
        //    //NavigationPage.SetHasBackButton(secondPage, false);

        //}
        //private async void Loadbtn(object sender, EventArgs e)
        //{
        //    var name = this.FindByName<Entry>("UserName");
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
        //    var secondPage = new MyMasterDetailPage();
        //    secondPage.BindingContext = contact;
        //    await Navigation.PushAsync(secondPage);
        //    //await _navigationService.NavigateAsync(new Uri($"MyMasterDetailPage", UriKind.Relative));


        //}
    }
}