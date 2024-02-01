using Database;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace WPF.Views
{
    /// <summary>
    /// Interaktionslogik für PopupForEdit.xaml
    /// </summary>
    public partial class PopupForEdit : Window
    {
        //Zeitlich nicht fertig geworden :(, deshalb ist es im UI erstmal versteckt 

        public PopupForEdit(Bird selectedBird)
        {
            InitializeComponent();
            _selectedBird = selectedBird;
            // Setzen des DataContexts für die Datenbindung an das ausgewählte Bird - Objekt
            DataContext = _selectedBird;
        }

        // Das ausgewählte Bird-Objekt
        private Bird _selectedBird;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            // Führt die Aktualisierung in der Datenbank durch
            Database.Program.Override(_selectedBird);

            // Schließt das Popup
            this.Close();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Schließt das Popup-Fenster
            Close();
        }

    }
}
