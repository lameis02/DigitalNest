using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Utilities;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class NavigationVM : ViewModelBase
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

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            CompleteGalleryCommand = new RelayCommand(CompleteGallery);
            FavoritesCommand = new RelayCommand(Favorites);
            StatisticsCommand = new RelayCommand(Statistics);

            //Start beim Home Bildschirm
            CurrentView = new HomeVM();
        }

        private void Home(object obj) => CurrentView = new HomeVM();

        private void CompleteGallery(object obj)
        {
            var completeGallery = new Views.CompleteGallery();
            completeGallery.GoToHomeRequested += (sender, e) => Home(null);
            CurrentView = completeGallery;
        }

        private void Favorites(object obj) => CurrentView = new FavouritesVM();
        private void Statistics(object obj) => CurrentView = new StatisticsVM();
    }
}

