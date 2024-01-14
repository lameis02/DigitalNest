using Microsoft.Win32;
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

namespace WPF.Views
{
    /// <summary>
    /// Interaktionslogik für Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()

        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BorderThickness = new Thickness(5);
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

        private string selectedImagePath;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Bild auswählen"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Der ausgewählte Bildpfad
                string selectedImagePath = openFileDialog.FileName;

                // Zeige das Popup-Fenster mit dem ausgewählten Bildpfad
                PopupForUpload imageView = new PopupForUpload(selectedImagePath);
                imageView.ShowDialog();
            }

        }
    }
}
