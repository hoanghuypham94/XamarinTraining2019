
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

            //if (buttonWithPadding == null)
            //    buttonWithPadding = e.NewElement as ButtonMenuRenderer;
            if (e.OldElement == null)
            {
                Control.Layer.CornerRadius = 3f;

                Control.Layer.BorderWidth = 3;
                Control.Layer.BorderColor = Color.Gray.ToCGColor();
                //Control.TextAlignment = UITextAlignment.Right;
            }

            //Thickness padding = buttonWithPadding.Padding;

            //if (padding.Left > 0)
            //{
            //    iosButton.ContentEdgeInsets = new UIEdgeInsets(
            //        new nfloat(padding.Top),
            //        new nfloat(padding.Left),
            //        new nfloat(padding.Bottom),
            //        new nfloat(padding.Right)
            //    );
            //}

        }
    }
}
