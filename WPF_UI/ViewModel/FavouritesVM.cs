using Database;
using System.Collections.ObjectModel;

namespace WPF.ViewModel
{
    class FavouritesVM: Utilities.ViewModelBase
    {
        // Konstruktor
        public FavouritesVM()
        {
            LoadFavsFromDatabase(); // Beim Initialisieren des ViewModels werden die Favoriten aus der Datenbank geladen
        }

        // ObservableCollection für die Anzeige der Favoriten in der Favoriten-Galerie
        public ObservableCollection<Bird> FavsGallery { get; set; } = new ObservableCollection<Bird>();

        // Methode zum Laden der Favoriten aus der Datenbank und Hinzufügen zu FavsGallery
        public void LoadFavsFromDatabase()
        {
            List<Bird> favsFromDatabase = Database.Program.SelectFavorite(true); // Holt alle Favoriten aus der Datenabnk mit dem Methdodenaufruf aus der Datenbank

            // Füllt die ObservableCollection mit den Favoriten aus der Datenbank
            foreach (var bird in favsFromDatabase)
            {
                FavsGallery.Add(bird);
            }
        }

        // Eigenschaft für den ausgewählten Vogel in der Galerie
        private Bird _selectedFav;

        public Bird SelectedFav
        {
            get { return _selectedFav; }
            set
            {
                if (_selectedFav != value) // Überprüft, ob der ausgewählte Vogel sich ändert
                {
                    _selectedFav = value;
                    OnPropertyChanged(nameof(SelectedFav)); // Benachrichtigt die UI über die Änderung der ausgewählten Eigenschaft
                    OnPropertyChanged(nameof(SelectedFavBytes)); // Benachrichtigt die UI über die Änderung der Bytes des ausgewählten Vogels

                }
            }
        }

        // Eigenschaft für die Bytes des ausgewählten Vogels
        public byte[] SelectedFavBytes => SelectedFav?.birdbytes;

        // Methode zum Setzen des ausgewählten Vogels
        public void SetSelectedFav(Bird bird)
        {
            SelectedFav = bird;
        }
    }
}
