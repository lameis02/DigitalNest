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
using System.Windows.Shapes;

namespace WPF.Views
{
    /// <summary>
    /// Interaktionslogik für PopupForUpload.xaml
    /// </summary>
    public partial class PopupForUpload : Window
    {
        public PopupForUpload(string selectedImagePath)
        {
            //Anzeige des Bildpfades in der oberen Textbox
            InitializeComponent();
            selectedImagePathTextBlock.Text = selectedImagePath;
        }
       

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(datePicker))
            {
                MessageBox.Show("Ungültiges Datumsformat. Bitte korrigiere es.");
                //für den Fall der Fälle, aber eig nicht nötig, da kein ungültiges Datum aufgrund von datepicker eingetragen werden kann
            }
            else
            {
                DateTime selectedDate = (DateTime)datePicker.SelectedDate; 
                // try catch für zukünftiges Datum abfangen noch einbauen
                // wenn kein Datum --> heutiges Datum eintragen über Add Methode von Datenbank (bearbeiten wenn gemerged ist)
                bool isFavorite = favoriteCheckBox.IsChecked ?? false;
                string vogelart = txtVogelart.Text;
                string ort = txtOrt.Text;
                DateTime datum = datePicker.SelectedDate ?? DateTime.Now;

                MessageBox.Show($"Bild hochgeladen am {datum}, als Favorit markiert: {isFavorite}");
                // Add Methode von Datenbank hochladen
            }

            
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //gilt für beide Textboxen
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // kein Text, wenn TextBox Fokus hat
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Platzerhaltertext, wenn Textbox leer ist
                textBox.Text = (textBox.Name == "txtVogelart") ? "Vogelart eintragen" : "Ort eintragen"; //unterschiedlicher Text je nach Box
                textBox.Foreground = Brushes.Gray; 
            }
        }
    }
}
