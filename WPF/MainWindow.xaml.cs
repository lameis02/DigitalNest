using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            menuToggleButton.Checked += menuToggleButton_Checked;
            menuToggleButton.Unchecked += menuToggleButton_Unchecked;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            menuPanel.Visibility = Visibility.Visible;
        }

        private void menuToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            menuPanel.Visibility = Visibility.Collapsed;
        }
    }
}
