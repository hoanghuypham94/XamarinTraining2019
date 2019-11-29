using System;
using System.Threading.Tasks;
using PostsImages.Effects;
using PostsImages.iOS.Effects;
using Prism.Navigation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("PostsImages")]
[assembly: ExportEffect(typeof(ButtonLongPressedEffectIOS), "ButtonLongPressedEffect")]

namespace PostsImages.iOS.Effects
{
    public class ButtonLongPressedEffectIOS : PlatformEffect
    {
        private bool _attached;
        private readonly UILongPressGestureRecognizer _longPressRecognizer;


        public ButtonLongPressedEffectIOS()
        {
                _longPressRecognizer = new UILongPressGestureRecognizer(HandleLongClick);
        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                Container.AddGestureRecognizer(_longPressRecognizer);
                _attached = true;
            }   
        }

        private void HandleLongClick()
        {

            if (_longPressRecognizer.State == UIGestureRecognizerState.Began)
            {
                var command = ButtonLongPressedEffect.GetCommand(Element);
                command?.Execute(ButtonLongPressedEffect.GetCommandParameter(Element));
            } 
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                Container.RemoveGestureRecognizer(_longPressRecognizer);
                _attached = false;
            }
        }

    }

}
