using Database;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // ausgewähltes Bird-Objekt aus dem DataContext des Bildes holen
            var selectedBird = ((Image)sender).DataContext as Bird;

            // Erstellung des Popup-Fensters
            var popUpWindow = new PopupForSingleImage(selectedBird);

            // Öffnen des Fensters
            popUpWindow.ShowDialog();
            
        }
    }
}
