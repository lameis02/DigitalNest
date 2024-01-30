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
    /// Interaktionslogik für PopupForEdit.xaml
    /// </summary>
    public partial class PopupForEdit : Window
    {
        private Bird _selectedBird;

        public PopupForEdit(Bird selectedBird)
        {
            InitializeComponent();
            DataContext = selectedBird;

            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            // Führen Sie die Aktualisierung in der Datenbank durch
            Database.Program.Override(_selectedBird);

            // Schließen Sie das Popup oder führen Sie andere Aktionen nach dem Speichern durch
            this.Close();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
