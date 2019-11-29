using System;
using Prism.Commands;
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

        private bool _isLogin;
        public bool IsLogin
        {
            get { return _isLogin; }
            set
            {
                if (_isLogin == value)
                    return;

                _isLogin = value;
                OnPropertyChanged("IsBusy");
            }
        }


        void TextcolorChanged(object sender, TextChangedEventArgs e)
        {
            IsLogin = false;
            //double result;
            //bool isValid = double.TryParse(e.NewTextValue, out result);

            //((Entry)sender).MaxLength <  ? Color.Default : Color.Red;
            bool isLength = e.NewTextValue.Length >= 8;
            //((Entry)sender).TextColor = isLength ? Color.Default : Color.Red;
            if (isLength == false)
            {
                ((Entry)sender).TextColor = Color.Red;// <8
                IsLogin = false;
            }
            else
            {
                ((Entry)sender).TextColor = Color.Black;
                //= isValid ? Color.Default : Color.Orange;
                IsLogin = true;
            }
        }

       
    }
}
