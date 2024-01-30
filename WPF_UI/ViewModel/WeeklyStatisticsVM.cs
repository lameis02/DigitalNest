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

        public WeeklyStatisticsVM()
        {
            _pageModel = new PageModel();
            LoadBirdData();
            LoadBarStatisticData();
        }

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

        //Balkendiagram

        private SeriesCollection _weeklyBirdBarSeries;
        public SeriesCollection WeeklyBirdBarSeries
        {
            get { return _weeklyBirdBarSeries; }
            set
            {
                _weeklyBirdBarSeries = value;
                OnPropertyChanged(nameof(WeeklyBirdBarSeries));
            }
        }

        public void LoadBarStatisticData()
        {
            Dictionary<string, int> weeklyBirdBarStatistic = StatisticCalculator.PrintMostCommonSpeciesAllTime();
            WeeklyBirdBarSeries = new SeriesCollection();

            foreach (string species in weeklyBirdBarStatistic.Keys)
            {
                var series = new ColumnSeries
                {
                    Title = species,
                    Values = new ChartValues<int> { weeklyBirdBarStatistic[species] }
                };

                WeeklyBirdBarSeries.Add(series);
            }

            // Aktualisieren Sie die Labels auf der X-Achse entsprechend den Vogelarten
            Labels = weeklyBirdBarStatistic.Keys.ToArray();

        }

        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
