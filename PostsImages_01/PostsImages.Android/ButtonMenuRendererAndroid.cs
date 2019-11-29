using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using PostsImages.Controls;
using PostsImages.Droid;

[assembly: ExportRenderer(typeof(ButtonMenuRenderer), typeof(ButtonMenuRendererAndroid))]
namespace PostsImages.Droid
{
    public class ButtonMenuRendererAndroid : ButtonRenderer
    {
        public ButtonMenuRendererAndroid(Context c) : base(c) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            UpdatePadding();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(ButtonMenuRenderer.Padding))
                UpdatePadding();
        }

        private void UpdatePadding()
        {
            ButtonMenuRenderer buttonWithPadding = Element as ButtonMenuRenderer;

            if (buttonWithPadding != null && buttonWithPadding.Padding.Left > 0)
            {
                Control.SetPadding(
                    (int)buttonWithPadding.Padding.Left,
                    (int)buttonWithPadding.Padding.Top,
                    (int)buttonWithPadding.Padding.Right,
                    (int)buttonWithPadding.Padding.Bottom
                );
            }

        }
    }
}
