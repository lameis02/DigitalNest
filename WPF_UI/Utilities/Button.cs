using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Utilities
{
     public class MyCustomButton : RadioButton
    {
        static MyCustomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomButton), new FrameworkPropertyMetadata(typeof(MyCustomButton)));
        }
    }
}
