using System;
using Xamarin.Forms;

namespace PostsImages.Controls
{
    public class ButtonMenuRenderer : Button
    {
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty PaddingProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(ButtonMenuRenderer), new Thickness(-1.0));
    }
}
