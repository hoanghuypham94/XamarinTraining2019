using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PostsImages.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostsImages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        

        public MyMasterDetailPageMaster()
        {
            

            InitializeComponent();

            BindingContext = new MyMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }



        class MyMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyMasterDetailPageMenuItem> MenuItems { get; set; }

            public MyMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MyMasterDetailPageMenuItem>(new[]
                {
                    new MyMasterDetailPageMenuItem { Id = 0, Title = "Thông tin cá nhân" },
                    new MyMasterDetailPageMenuItem { Id = 1, Title = "Duyệt hình ảnh" },
                    new MyMasterDetailPageMenuItem { Id = 2, Title = "Hình ảnh chi tiết" },


                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
        //private void LoguotCommand(object sender, EventArgs e)
        //{
        //    Application.Current.MainPage = new NavigationPage(new LoginMyView());
        //}

    }
}
