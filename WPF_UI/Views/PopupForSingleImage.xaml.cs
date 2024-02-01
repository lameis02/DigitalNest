using Database;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace WPF.Views
{

    public partial class PopupForSingleImage : Window
    {
        // Das ausgewählte Bird-Objekt
        private Bird _selectedBird;

        // Konstruktor
        public PopupForSingleImage(Bird selectedBird)
        {
            InitializeComponent();
            _selectedBird = selectedBird;
            // Setzen des DataContexts für die Datenbindung an das ausgewählte Bird-Objekt
            DataContext = _selectedBird;
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close(); // Schließt das Popup-Fenster
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Öffnet ein Popup-Fenster für die Bearbeitung des ausgewählten Vogels
            var editPopup = new PopupForEdit(_selectedBird);
            editPopup.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Zeigt eine Bestätigungsfrage für das Löschen an
            MessageBoxResult result = MessageBox.Show("Möchten Sie diesen Vogel wirklich löschen?", "Löschen bestätigen", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //Bestätigung des Löschens
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
