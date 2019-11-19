using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PostsImages.Models;
using Prism.Navigation;
using Xamarin.Forms;

namespace PostsImages.Views
{
    public partial class LoginMyView : ContentPage
    {
        //INavigationService _navigationService;
        public LoginMyView()
        {
            InitializeComponent();

            //_navigationService = navigationService;

        }

        private void Usernamechanged(object sender, TextChangedEventArgs e)
        {
            var enty = (Entry)sender;

            try
            {
                if (enty.Text.Length >= 8 && Password.Text.Length >= 8)
                {
                    Loginbtn.IsVisible = true;
                    MesssageError.IsVisible = false;
                }
                else
                {
                    Loginbtn.IsVisible = false;
                    MesssageError.IsVisible = true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
        }

        private void Passwordchanged(object sender, TextChangedEventArgs e)
        {
            var enty = (Entry)sender;
            bool match = Regex.IsMatch(enty.Text, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
            try
            {
                if (match == true && UserName.Text.Length >= 8)
                {
                    Loginbtn.IsVisible = true;
                    MesssageError.IsVisible = false;
                }
                else
                {
                    Loginbtn.IsVisible = false;
                    MesssageError.IsVisible = true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
        }

        //private void LoginFacebook(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new FacebookProfilePage());
        //}

        //private async void LoginGoogle(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new GoogleProfilePage());
        //}



        //private void OnLogin(object sender, EventArgs e)
        //{
        //    var name = this.FindByName<Entry>("UserName");
        //    var pass = this.FindByName<Entry>("Password");

        //    var contact = new UserModel()
        //    {
        //        UserName = name.Text,
        //        Password = pass.Text,

        //    };
        //    var secondPage = new MyMasterDetailPage();
        //    secondPage.BindingContext = contact;
        //    Navigation.PushModalAsync(secondPage);
        //    //NavigationPage.SetHasBackButton(secondPage, false);
        //    //await NavigationPage(new ShowImagesPageMyView());
        //    //await _navigationService.NavigateAsync($"/MyMasterDetailPage");
        //    //await _navigationService.NavigateAsync(new Uri($"MyMasterDetailPage", UriKind.Relative));

        //}
    }
}
