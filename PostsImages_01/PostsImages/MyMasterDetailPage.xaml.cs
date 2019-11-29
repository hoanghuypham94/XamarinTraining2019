using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostsImages.Views;
using Prism.Mvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostsImages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMasterDetailPage : MasterDetailPage
    {
        public MyMasterDetailPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MyMasterDetailPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            switch (item.Id)
            {
                case 0:
                    //Navigation.PushAsync(new InfoOfUserMyView());
                    Detail = new NavigationPage(new InfoOfUserMyView());
                    IsPresented = false;
                    break;
                case 1:
                    Detail = new NavigationPage(new ShowImagesPageMyView());
                    IsPresented = false;
                    break;
                case 2:
                    Detail = new NavigationPage(new DetailImageMyView());
                    IsPresented = false;
                    break;
            }

            MasterPage.ListView.SelectedItem = null;
        }




    }
}
