using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            List<Bird> birdsFromDatabase = Database.Program.Select();

            // Observable Collection wird mit allen Vögeln aus der Datenbank gefüllt
            foreach (var bird in birdsFromDatabase)
            {
                BirdGallery.Add(bird);
            }
        }

        private Bird _selectedBird;

        public Bird SelectedBird
        {
            get { return _selectedBird; }
            set
            {
                if (_selectedBird != value)
                {
                    _selectedBird = value;
                    OnPropertyChanged(nameof(SelectedBird));
                    OnPropertyChanged(nameof(SelectedBirdBytes));
                }

                Debug.WriteLine($"SelectedBird changed to: {_selectedBird}");
            }
        }

        public byte[] SelectedBirdBytes => SelectedBird?.birdbytes;

        public void SetSelectedBird(Bird bird)
        {
            SelectedBird = bird;
        }


    }

}
