
using PostsImages.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ButtonMenuRenderer), typeof(PostsImages.iOS.ButtonMenuRendererIOS))]
namespace PostsImages.iOS
{
    public class ButtonMenuRendererIOS : ButtonRenderer
    {
        public ButtonMenuRendererIOS() : base()
        {
        }

        protected ButtonMenuRenderer buttonWithPadding;

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

           
            if (e.OldElement == null)
            {
                Control.Layer.CornerRadius = 3f;

                Control.Layer.BorderWidth = 3;
                Control.Layer.BorderColor = Color.Gray.ToCGColor();
                
            }

            

        }
    }
}
