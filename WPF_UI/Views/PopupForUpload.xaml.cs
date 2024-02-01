using Database;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.Views
{
    
    public partial class PopupForUpload : Window
    {
        public PopupForUpload(string selectedImagePath)
        {
            InitializeComponent();
            //Anzeige des Bildpfades in der oberen Textbox
            selectedImagePathTextBlock.Text = selectedImagePath;
            
        }

        private string lastIdentificationResult;

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            string location;
            string species;

            // Überprüfung und Zuweisung von Standardwerten für Ort und Vogelart
            DateTime selectedDate = (DateTime)datePicker.SelectedDate; 
            bool isFav = favoriteCheckBox.IsChecked ?? false;
            DateTime date = selectedDate;
            string selectedImagePath = selectedImagePathTextBlock.Text;
            if (txtOrt.Text == "Ort eintragen")
                location = "unbekannt";
            else
                location = txtOrt.Text;
            if (txtVogelart.Text == "Vogelart eintragen")
                species = "unbekannt";
            else
                species = txtVogelart.Text;


            Bird newBird = new Bird 
                {
                    Species = species,
                    Date = date,
                    Location = location,
                    ImagePath = selectedImagePath,
                    IsFavorite = isFav
                };

            Database.Program.Add(newBird);


            MessageBox.Show($"Das Bild wurde erfolgreich hochgeladen!");

            Close();
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

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
            //wenn Zeit: beim rüber hovern wird kreuz rot
        }

        private void datePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            //zeigt an, dass Eregniss bereits vollständig behandelt wurde --> Benutzer kann das Datum nicht mehr manuell verändern
        }

        /*private async void IdentifyMoreButton_Click(object sender, RoutedEventArgs e)
        {
            string result = await Vogelscheuche_Bib.AI_Service.MultiResponse(new HttpClient(), "http://localhost:5000/birds/", selectedImagePathTextBlock.Text);
            txtVogelart.Foreground = Brushes.Black;
            txtVogelart.Text = result;
            //merhfaches Speichern, wenn verschiedene Vogelarten auf dem Bild sind
        }*/

        private async void IdentifyOneButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Anzeigen des Ladebalkens
                loadingProgressBar.Visibility = Visibility.Visible;

                if (!string.IsNullOrEmpty(lastIdentificationResult))
                {
                    txtVogelart.Foreground = Brushes.Black;
                    txtVogelart.Text = lastIdentificationResult;
                }
                else
                {

                    string result = await Vogelscheuche_Bib.AI_Service.SingleResponse(new HttpClient(), "http://localhost:5000/BOPS/", selectedImagePathTextBlock.Text);
                    txtVogelart.Foreground = Brushes.Black;
                    txtVogelart.Text = result;

                    // Zwischenspeichern des Ergebnisses für mehreres Klicken auf Button
                    lastIdentificationResult = result;
                }
            }
            finally
            {
                // Verstecken des Ladebalkens
                loadingProgressBar.Visibility = Visibility.Hidden;
            }
        }
    }
}
