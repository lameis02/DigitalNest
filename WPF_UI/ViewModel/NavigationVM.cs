﻿
using WPF.Utilities;
using System.Windows.Input;

namespace WPF.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }

        }

        public ICommand HomeCommand { get; set; }
        public ICommand CompleteGalleryCommand { get; set; }
        public ICommand FavoritesCommand { get; set; }
        public ICommand StatisticsCommand { get; set; }
        public ICommand WeeklyStatisticsCommand { get; set; }

        // Methoden zum Wechseln der Bildschirme in der Menüleiste
        private void Home(object obj) => CurrentView = new HomeVM();
        private void CompleteGallery(object obj) => CurrentView = new CompleteGalleryVM();
        private void Favorites(object obj) => CurrentView = new FavouritesVM();
        private void Statistics(object obj) => CurrentView = new StatisticsVM();
        private void WeeklyStatistics(object obj) => CurrentView = new WeeklyStatisticsVM();

        //Konstruktor initialisiert Befehle/Commands
        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            CompleteGalleryCommand = new RelayCommand(CompleteGallery);
            FavoritesCommand = new RelayCommand(Favorites);
            StatisticsCommand = new RelayCommand(Statistics);
            WeeklyStatisticsCommand = new RelayCommand(WeeklyStatistics);

            //Start beim Home Bildschirm
            CurrentView = new HomeVM();
        }

    }
}
