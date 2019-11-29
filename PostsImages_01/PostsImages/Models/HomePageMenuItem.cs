using System;
using PostsImages.Views;

namespace PostsImages.Models
{
    public class HomePageMenuItem
    {
        public HomePageMenuItem()
        {
            TargetType = typeof(MainPageView);
        }
        public int Id { get; set; }
        public string TitleMenu { get; set; }
        public string PageName { get; set; }

        public Type TargetType { get; set; }
    }
}
