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
    class StatisticsVM: Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public StatisticsVM()
        {
            _pageModel = new PageModel();
            LoadPieStatisticData();
            LoadBarStatisticData();
        }

        //Kreisdiagram

        private SeriesCollection _birdPieSeries;
        public SeriesCollection BirdPieSeries
        {
            get { return _birdPieSeries; }
            set
            {
                _birdPieSeries = value;
                OnPropertyChanged(nameof(BirdPieSeries));
            }
        }

        private void LoadPieStatisticData()
        {
            Dictionary<string, int> birdPieStatistics = StatisticCalculator.PrintBirdStatisticsAllTime();

            BirdPieSeries = new SeriesCollection();
            foreach (var day in birdPieStatistics.Keys)
            {
                var series = new PieSeries
                {
                    Title = day,
                    Values = new ChartValues<int> { birdPieStatistics[day] },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{chartPoint.Y} Vögel"
                };

                BirdPieSeries.Add(series);
            }
        }

        //Balkendiagram

        private SeriesCollection _birdBarSeries;
        public SeriesCollection BirdBarSeries
        {
            get { return _birdBarSeries; }
            set
            {
                _birdBarSeries = value;
                OnPropertyChanged(nameof(BirdBarSeries));
            }
        }

        public void LoadBarStatisticData()
        {
            Dictionary<string, int> birdBarStatistic = StatisticCalculator.PrintMostCommonSpeciesAllTime();
            BirdBarSeries = new SeriesCollection();

            foreach (string species in birdBarStatistic.Keys)
            {
                var series = new ColumnSeries
                {
                    Title = species,
                    Values = new ChartValues<int> { birdBarStatistic[species] }
                };

                BirdBarSeries.Add(series);
            }

            // Aktualisieren Sie die Labels auf der X-Achse entsprechend den Vogelarten
            Labels = birdBarStatistic.Keys.ToArray();

        }

        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }


    }
}
