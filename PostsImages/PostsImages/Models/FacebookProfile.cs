using System;
using System.ComponentModel;
using Xamarin.Forms;
namespace PostsImages.Models
{
    public class AgeRange
    {
        public int min { get; set; }
    }

    public class Data
    {
        public int height { get; set; }
        public bool is_silhouette { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Picture
    {
        public Data data { get; set; }
    }

    public class FacebookProfile
    {
        public string id { get; set; }
        public string name { get; set; }
        public AgeRange age_range { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public UriImageSource picture { get; set; }
        public string birthday { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
    }

}
