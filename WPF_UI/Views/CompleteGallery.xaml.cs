using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.ViewModel;

namespace WPF.Views
{
    
    public partial class CompleteGallery : UserControl
    {
        public event EventHandler GoToHomeRequested;

        public CompleteGallery()
        {
            InitializeComponent();
        }

        private void DeleteAllImages_Click(object sender, RoutedEventArgs e)
        {
            // Bestätigungspopup öffnen
            deleteConfirmationPopup.IsOpen = true;
        }

        private void DeleteAllConfirmed_Click(object sender, RoutedEventArgs e)
        {
            // Popup schließen
            deleteConfirmationPopup.IsOpen = false;

            // Aufruf der DeleteAll() Methode in der Datenbank
            Database.Program.DeleteAll();

            // Rufe das Event auf, um zur Home-Ansicht zu wechseln
            GoToHomeRequested?.Invoke(this, EventArgs.Empty);
        }

        private void DeleteAllCancelled_Click(object sender, RoutedEventArgs e)
        {
            // Popup schließen
            deleteConfirmationPopup.IsOpen = false;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BorderThickness = new Thickness(2);
                button.BorderBrush = Brushes.Black;
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BorderThickness = new Thickness(1);
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 100, 66));
            }
        }
    }
}
