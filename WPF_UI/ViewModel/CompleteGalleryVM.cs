using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.ViewModel
{
    class CompleteGalleryVM: Utilities.ViewModelBase
    {

        private readonly PageModel _pageModel;
        
        public CompleteGalleryVM()
        {
            _pageModel = new PageModel();
            LoadBirdsFromDatabase();

        }

        public ObservableCollection<byte[]> BirdGallery { get; set; } = new ObservableCollection<byte[]>();

        public void LoadBirdsFromDatabase()
        {
            List<byte[]> imageBytesFromDatabase = Database.Program.Select();

            // Observable Collection wird mit allen Bildern in byte[] gefüllt
            foreach (var imageBytes in imageBytesFromDatabase)
            {
                BirdGallery.Add(imageBytes);
            }

        }


    }

}
