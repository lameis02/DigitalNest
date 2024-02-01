using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.Views
{
    /// <summary>
    /// Interaktionslogik für Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        // Konstruktor
        public Home()
        {
            InitializeComponent();
        }

        private void UploadButton_MouseEnter(object sender, MouseEventArgs e) //Hervorheben, wenn Mauszeiger üben dem UploadButton ist
        {
            Button button = sender as Button;
            button.BorderThickness = new Thickness(5);         
        }

        private void UploadButton_MouseLeave(object sender, MouseEventArgs e) //Zurücksetzen des DeleteAllButtons, wenn Mauszeiger nicht mehr auf dem Button ist
        {
            Button button = sender as Button;
            button.BorderThickness = new Thickness(1);
        }

        // Pfad für das ausgewählte Bild
        private string selectedImagePath;

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog // Öffnet einen Dialog zum Auswählen einer Bilddatei
            {
                Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Bild auswählen"
            };


            if (openFileDialog.ShowDialog() == true) // Wenn der Benutzer eine Datei ausgewählt hat
            {
                string selectedImagePath = openFileDialog.FileName; // Setzt den Pfad der ausgewählten Bilddatei

                PopupForUpload popupForUploadView = new PopupForUpload(selectedImagePath); // Öffnet ein Popup-Fenster mit dem ausgewählten Bildpfad
                popupForUploadView.ShowDialog();
            }

        }
    }
}
