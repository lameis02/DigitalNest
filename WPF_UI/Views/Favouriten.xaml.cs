using Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPF.Views
{
    /// <summary>
    /// Interaktionslogik für Favoriten.xaml
    /// </summary>
    public partial class Favoriten : UserControl
    {
        public Favoriten()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BorderThickness = new Thickness(2);
                button.BorderBrush = Brushes.Black;
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BorderThickness = new Thickness(1);
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 100, 66));
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // ausgewählte Bird-Objekt aus dem DataContext des Bildes holen
            var selectedBird = ((Image)sender).DataContext as Bird;

            // Überprüfen Sie, ob ein Vogel ausgewählt wurde
            if (selectedBird != null)
            {
                Debug.WriteLine($"Selected bird: {selectedBird}");

                // Erstellung des Popup-Fensters
                var popUpWindow = new PopupForSingleImage(selectedBird);

                // Öffnen des Fensters
                popUpWindow.ShowDialog();
            }
        }
    }
}
