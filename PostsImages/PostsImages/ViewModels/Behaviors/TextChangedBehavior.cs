using System;
using Xamarin.Forms;

namespace PostsImages.ViewModels.Behaviors
{
    public class TextChangedBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += TextcolorChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= TextcolorChanged;
            base.OnDetachingFrom(bindable);
        }

        void TextcolorChanged(object sender, TextChangedEventArgs e)
        {
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);

            //((Entry)sender).MaxLength <  ? Color.Default : Color.Red;
            bool isLength = e.NewTextValue.Length >= 8;
            //((Entry)sender).TextColor = isLength ? Color.Default : Color.Red;
            if (isLength == false)
            {
                ((Entry)sender).TextColor = Color.Red;// <8
                
            }
            else
            {
                ((Entry)sender).TextColor = Color.Black;
                    //= isValid ? Color.Default : Color.Orange;
            }
        }
    }
}
