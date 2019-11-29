using System;
using Xamarin.Forms;

namespace PostsImages.Controls
{
    public class ButtonMenuRenderer : Button
    {
        public Thickness Paddings
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty PaddingsProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(ButtonMenuRenderer), new Thickness(-10.0));
    }
}
