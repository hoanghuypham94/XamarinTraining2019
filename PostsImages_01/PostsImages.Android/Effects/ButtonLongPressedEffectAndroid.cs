using System;
using PostsImages.Droid.Effects;
using PostsImages.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("PostsImages")]
[assembly: ExportEffect(typeof(ButtonLongPressedEffectAndroid), "ButtonLongPressedEffect")]

namespace PostsImages.Droid.Effects
{
    public class ButtonLongPressedEffectAndroid : PlatformEffect
    {
        private bool _attached;
        public static void Initialize() { }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.LongClick += Control_LongClick;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.LongClick += Control_LongClick;
                }
                _attached = true;
            }
        }

        private void Control_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            var command = ButtonLongPressedEffect.GetCommand(Element);
            command?.Execute(ButtonLongPressedEffect.GetCommandParameter(Element));
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.LongClick -= Control_LongClick;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.LongClick -= Control_LongClick;
                }
                _attached = false;
            }
        }
    }
}