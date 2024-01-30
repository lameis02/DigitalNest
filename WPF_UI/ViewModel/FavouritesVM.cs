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
    class FavouritesVM: Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;


        public FavouritesVM()
        {
            _pageModel = new PageModel();
            LoadFavsFromDatabase();
        }

        public ObservableCollection<Bird> FavsGallery { get; set; } = new ObservableCollection<Bird>();

        public void LoadFavsFromDatabase()
        {
            List<Bird> favsFromDatabase = Database.Program.SelectFavorite(true);

            // Observable Collection wird mit allen Vögeln aus der Datenbank gefüllt
            foreach (var bird in favsFromDatabase)
            {
                FavsGallery.Add(bird);
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
            }
        }

        public byte[] SelectedBirdBytes => SelectedBird?.birdbytes;

        public void SetSelectedBird(Bird bird)
        {
            SelectedBird = bird;
        }
    }
}
