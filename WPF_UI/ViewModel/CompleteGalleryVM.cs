using Database;
using System.Collections.ObjectModel;

namespace WPF.ViewModel
{
    class CompleteGalleryVM: Utilities.ViewModelBase
    {

        // Konstruktor
        public CompleteGalleryVM()
        {
            LoadBirdsFromDatabase(); // Beim Initialisieren des ViewModels werden die Vögel aus der Datenbank geladen
        }

        // ObservableCollection für die Anzeige der Vögel in der Galerie
        public ObservableCollection<Bird> BirdGallery { get; set; } = new ObservableCollection<Bird>();

        // Methode zum Laden der Vögel aus der Datenbank und Hinzufügen zu BirdGallery
        public void LoadBirdsFromDatabase()
        {
            List<Bird> birdsFromDatabase = Database.Program.Select(); // Holt alle Vögel aus der Datenbank mit dem Methdodenaufruf aus der Datenbank

            // Füllt die ObservableCollection mit den Vögeln aus der Datenbank
            foreach (var bird in birdsFromDatabase)
            {
                BirdGallery.Add(bird);
            }
        }

        // Eigenschaft für den ausgewählten Vogel in der Galerie
        private Bird _selectedBird;

        public Bird SelectedBird
        {
            get { return _selectedBird; }
            set
            {
                if (_selectedBird != value) // Überprüft, ob der ausgewählte Vogel sich ändert
                {
                    _selectedBird = value; // Überprüft, ob der ausgewählte Vogel sich ändert
                    OnPropertyChanged(nameof(SelectedBird)); // Benachrichtigt die UI über die Änderung der ausgewählten Eigenschaft
                    OnPropertyChanged(nameof(SelectedBirdBytes)); // Benachrichtigt die UI über die Änderung der Bytes des ausgewählten Vogels

                }
            }
        }

        // Eigenschaft für die Bytes des ausgewählten Vogels
        public byte[] SelectedBirdBytes => SelectedBird?.birdbytes;

        // Methode zum Setzen des ausgewählten Vogels
        public void SetSelectedBird(Bird bird)
        {
            SelectedBird = bird;
        }


    }

}
