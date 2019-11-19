using System;
using System.Collections.Generic;
using System.Windows.Input;
using PostsImages.ViewModels;
using Xamarin.Forms;

namespace PostsImages.Views
{
    public partial class FacebookProfilePage : ContentPage
    {
        
        private string ClientId = "1016421818567920";

        public FacebookProfilePage()
        {
            InitializeComponent();
            
            var apiRequest =
                "https://www.facebook.com/v5.0/dialog/oauth?client_id="
                + ClientId
                + "&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";
            //https://www.facebook.com/v5.0/dialog/oauth?client_id=l1016421818567920&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.htm
            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {

            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                var vm = BindingContext as FacebookViewModel;

                await vm.SetFacebookUserProfileAsync(accessToken);

                Content = MainStackLayout;
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;
        }


        private void Comeback(object sender, EventArgs e)
        {
             Navigation.PushModalAsync(new LoginMyView());
        }
    }
}