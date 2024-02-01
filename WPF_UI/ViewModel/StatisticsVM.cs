using LiveCharts;
using LiveCharts.Wpf;
using Vogelscheuche_Bib;

namespace WPF.ViewModel
{
    class StatisticsVM: Utilities.ViewModelBase
    {
        // Konstruktor
        public StatisticsVM()
        {
            // Beim Erstellen des ViewModel werden die Daten für das Kreis- und Balkendiagramm geladen
            LoadPieStatisticData();
            LoadBarStatisticData();
        }

        // Eigenschaft für das Kreisdiagramm
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
            // Statistikdaten für das Kreisdiagramm abrufen
            Dictionary<string, int> birdPieStatistics = StatisticCalculator.PrintBirdStatisticsAllTime();

            // SerieCollection für das Kreisdiagramm erstellen
            BirdPieSeries = new SeriesCollection();
            foreach (var day in birdPieStatistics.Keys)
            {
                // Serie für jeden Tag erstellen
                PieSeries series = new PieSeries
                {
                    Title = day,
                    Values = new ChartValues<int> { birdPieStatistics[day] },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{chartPoint.Y} {(chartPoint.Y == 1 ? "Vogel" : "Vögel")}"

                };

                // Serie zur SerieCollection hinzufügen
                BirdPieSeries.Add(series);
            }
        }

        // Eigenschaft für das Balkendiagramm
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
            // Statistikdaten für das Balkendiagramm abrufen
            Dictionary<string, int> birdBarStatistic = StatisticCalculator.PrintMostCommonSpeciesAllTime();
            BirdBarSeries = new SeriesCollection();

            foreach (string species in birdBarStatistic.Keys)
            {
                // Serie für jede Vogelart erstellen
                ColumnSeries series = new ColumnSeries
                {
                    Title = species,
                    Values = new ChartValues<int> { birdBarStatistic[species] }
                };

                // Serie zur SerieCollection hinzufügen
                BirdBarSeries.Add(series);
            }

            // Labels auf der X-Achse aktualisieren, um den Vogelarten zu entsprechen
            Labels = birdBarStatistic.Keys.ToArray();

        }

        // Eigenschaft für die Labels auf der X-Achse des Balkendiagramms
        public string[] Labels { get; set; }
        // Funktion zum Formatieren der Werte auf der Y-Achse des Balkendiagramms
        public Func<double, string> Formatter { get; set; }


    }
}
