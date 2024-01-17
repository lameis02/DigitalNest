using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.ViewModel
{
    class FavouritesVM: Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;


        public FavouritesVM()
        {
            _pageModel = new PageModel();
            LoadFavsFromDatabase();
        }

        public ObservableCollection<byte[]> FavGallery { get; set; } = new ObservableCollection<byte[]>();

        public void LoadFavsFromDatabase()
        {
            List<byte[]> imageBytesFromDatabase = Database.Program.SelectFavorite(true);

            // Observable Collection wird mit allen Bildern in byte[] gefüllt
            foreach (var imageBytes in imageBytesFromDatabase)
            {
                FavGallery.Add(imageBytes);
            }

        }
    }
}
