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

        public ObservableCollection<Bird> BirdGallery { get; set; } = new ObservableCollection<Bird>();

        public void LoadBirdsFromDatabase()
        {
            /*List<string> imagePathsFromDatabase = Database.Program.

            // Observable Collection wird mit allen Bildpfaden gefüllt
            foreach (var imagePath in imagePathsFromDatabase)
            {
                BirdGallery.Add(new Bird { ImagePath = imagePath });
            }*/

        }


    }

}
