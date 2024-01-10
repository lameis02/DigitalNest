using Database;
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
           
                DateTime selectedDate = (DateTime)datePicker.SelectedDate; 
                bool isFav = favoriteCheckBox.IsChecked ?? false;
                string vogelart = txtVogelart.Text;
                string ort = txtOrt.Text;
                DateTime datum = selectedDate;
                string selectedImagePath = selectedImagePathTextBlock.Text;

                Bird neuerVogel = new Bird 
                {
                    
                    Species = vogelart,
                    Date = datum,
                    Location = ort,
                    ImagePath = selectedImagePath,
                    IsFavorite = isFav
                };

            Database.Program.Add(neuerVogel);


            MessageBox.Show($"Bild hochgeladen am {datum}, als Favorit markiert: {isFav}");

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
    }
}
