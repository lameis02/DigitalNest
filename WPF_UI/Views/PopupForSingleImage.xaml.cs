using Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

    public partial class PopupForSingleImage : Window
    {
        private Bird _selectedBird;

        public PopupForSingleImage(Bird selectedBird)
        {
            InitializeComponent();
            _selectedBird = selectedBird;

            Debug.WriteLine($"DataContext set to: {_selectedBird}");

            DataContext = _selectedBird;
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var editPopup = new PopupForEdit(_selectedBird);
            editPopup.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Möchten Sie diesen Vogel wirklich löschen?", "Löschen bestätigen", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                // Löschen in der Datenbank
                Database.Program.Delete(_selectedBird.ID);

                // Schließen Sie das Popup-Fenster
                Close();
            }
        }
    }
}
