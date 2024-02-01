using Database;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.Views
{
    public partial class CompleteGallery : UserControl
    {
        public event EventHandler GoToHomeRequested;

        public CompleteGallery()
        {
            InitializeComponent();
        }

        private void DeleteAllImages_Click(object sender, RoutedEventArgs e) //Button zum Löschen aller Bilder
        {
            deleteConfirmationPopup.IsOpen = true; //öffnet Bestätigungs Popup
        }

        private void DeleteAllConfirmed_Click(object sender, RoutedEventArgs e) //User klickt beim Bestätigungs Popup auf "ja"
        {
            // Popup schließen
            deleteConfirmationPopup.IsOpen = false;

            // Aufruf der DeleteAll() Methode in der Datenbank
            Database.Program.DeleteAll();
        }

        private void DeleteAllCancelled_Click(object sender, RoutedEventArgs e) //User klickt beim Bestätigungs Popup auf "nein"
        {
            // Popup schließen
            deleteConfirmationPopup.IsOpen = false;
        }

        private void DeleteAllButton_MouseEnter(object sender, MouseEventArgs e) //Hervorheben, wenn Mauszeiger üben dem DeleteAllButton ist
        {
            Button button = sender as Button;
            button.BorderThickness = new Thickness(2);
            button.BorderBrush = Brushes.Black;
            
        }

        private void DeleteAllButton_MouseLeave(object sender, MouseEventArgs e)//Zurücksetzen des DeleteAllButtons, wenn Mauszeiger nicht mehr auf dem Button ist
        {
            Button button = sender as Button;
            button.BorderThickness = new Thickness(1);
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 100, 66));
            
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // ausgewählte Bird-Objekt aus dem DataContext des Bildes holen
            Bird selectedBird = ((Image)sender).DataContext as Bird;

            // Erstellung des Popup-Fensters
            var popUpWindow = new PopupForSingleImage(selectedBird);

            // Öffnen des Fensters
            popUpWindow.ShowDialog();
            
        }
    }
}
