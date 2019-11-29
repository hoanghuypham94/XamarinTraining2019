using System;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace PostsImages.Effects
{
    public class ButtonLongPressedEffect : RoutingEffect
    {
        
        public ButtonLongPressedEffect() : base("PostsImages.ButtonLongPressedEffect"){   }

        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(
            "Command", typeof(ICommand), typeof(ButtonLongPressedEffect), (object)null);
        public static ICommand GetCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(CommandProperty);
        }

        public static void SetCommand(BindableObject view, ICommand value)
        {
            view.SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.CreateAttached(
            "CommandParameter", typeof(object), typeof(ButtonLongPressedEffect), (object)null);
        public static object GetCommandParameter(BindableObject view)
        {
            return view.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(BindableObject view, object value)
        {
            view.SetValue(CommandParameterProperty, value);
        }
    }
}
