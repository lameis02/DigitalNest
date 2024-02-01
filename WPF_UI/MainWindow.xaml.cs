using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                // Ändern der Darstellung, wenn die Maus über dem Button ist
                button.BorderThickness = new Thickness(5);
                button.BorderBrush = Brushes.Black;
            }

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                // Ändern der Darstellung, wenn die Maus den Button verlässt
                button.BorderThickness = new Thickness(1);
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(120, 100, 66));
            }
        }


        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            // Schließt das Hauptfenster
            Close();
        }


    }
}