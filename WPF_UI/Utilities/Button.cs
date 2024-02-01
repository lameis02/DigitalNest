using System.Windows;
using System.Windows.Controls;

namespace WPF.Utilities
{
     public class MyCustomButton : RadioButton
    {
        static MyCustomButton()
        {
            // Überschreiben des Standard-Stil-Schlüsselwerts für die Verwendung des benutzerdefinierten Stils
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomButton), new FrameworkPropertyMetadata(typeof(MyCustomButton)));
        }
    }
}
