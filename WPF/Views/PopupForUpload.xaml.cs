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
            InitializeComponent();
            selectedImagePathTextBlock.Text = selectedImagePath;
        }
       

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            string vogelart = txtVogelart.Text;
            string ort = txtOrt.Text;
            DateTime datum = datePicker.SelectedDate ?? DateTime.Now;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //gilt für beide Textboxen
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // kein Text, wenn TextBox Fokus hat
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black; // Ändere die Schriftfarbe auf Schwarz oder eine andere Farbe nach Bedarf
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
