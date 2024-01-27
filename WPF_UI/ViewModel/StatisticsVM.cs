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

        public StatisticsVM()
        {
            _pageModel = new PageModel();
            LoadBirdData();
        }

        private void LoadBirdData()
        {
            Dictionary<string, int> birdStatistics = StatisticCalculator.PrintBirdStatisticsAllTime();

            BirdPieSeries = new SeriesCollection();
            foreach (var day in birdStatistics.Keys)
            {
                var series = new PieSeries
                {
                    Title = day,
                    Values = new ChartValues<int> { birdStatistics[day] },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{chartPoint.Y} Vögel"
                };

                BirdPieSeries.Add(series);
            }
        }

        
    }
}
