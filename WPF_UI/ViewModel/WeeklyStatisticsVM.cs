using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogelscheuche_Bib;
using WPF.Model;

namespace WPF.ViewModel
{
    class WeeklyStatisticsVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        private SeriesCollection _birdPieSeriesWeekly;
        public SeriesCollection BirdPieSeriesWeekly
        {
            get { return _birdPieSeriesWeekly; }
            set
            {
                _birdPieSeriesWeekly = value;
                OnPropertyChanged(nameof(BirdPieSeriesWeekly));
            }
        }

        private SeriesCollection _mostCommonSpeciesBarSeries;
        public SeriesCollection MostCommonSpeciesBarSeries
        {
            get { return _mostCommonSpeciesBarSeries; }
            set
            {
                _mostCommonSpeciesBarSeries = value;
                OnPropertyChanged(nameof(MostCommonSpeciesBarSeries));
            }
        }

        public WeeklyStatisticsVM()
        {
            _pageModel = new PageModel();
            LoadBirdData();
            LoadMostCommonSpeciesLast7Days();
        }

        private void LoadBirdData()
        {
            Dictionary<string, int> birdStatistics = StatisticCalculator.PrintBirdStatisticsLast7Days();

            BirdPieSeriesWeekly = new SeriesCollection();
            foreach (var day in birdStatistics.Keys)
            {
                var series = new PieSeries
                {
                    Title = day,
                    Values = new ChartValues<int> { birdStatistics[day] },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{chartPoint.Y} Vögel"
                };

                BirdPieSeriesWeekly.Add(series);
            }
        }

        private void LoadMostCommonSpeciesLast7Days()
        {
            Dictionary<string, int> speciesCount = StatisticCalculator.PrintMostCommonSpeciesLast7Days();

            // Kreiere die Serie für das Balkendiagramm
            MostCommonSpeciesBarSeries = new SeriesCollection();

            foreach (var species in speciesCount.Keys)
            {
                MostCommonSpeciesBarSeries.Add(new ColumnSeries
                {
                    Title = species,
                    Values = new ChartValues<int> { speciesCount[species] }
                });
            }
        }
    }
}
