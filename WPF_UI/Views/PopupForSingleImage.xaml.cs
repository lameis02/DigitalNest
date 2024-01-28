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

            // Setzen Sie die DataContext auf sich selbst, um direkt auf das _selectedBird zuzugreifen
            DataContext = this;
        }
    }
}
