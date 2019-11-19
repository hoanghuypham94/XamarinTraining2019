using System;
using Android.Content;
using Android.Graphics.Drawables;
using PostsImages.Droid;
using PostsImages.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderEntry), typeof(BorderEntryRendererAndroid))]
namespace PostsImages.Droid
{
    public class BorderEntryRendererAndroid : EntryRenderer
    {
        public BorderEntryRendererAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry>e)
        {
        base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(3f);
        //        //gradientDraws.Color.Red);
        //        gradientDrawable.SetColor(Android.Graphics.Color.Green); able.SetStroke(3, Android.Graphic) Control.SetBackground(gradientDrawable);
        //Control.Gravity = GravityFlags.CenterVertical | GravityFlags.Left;
            }
        }
    }
}
