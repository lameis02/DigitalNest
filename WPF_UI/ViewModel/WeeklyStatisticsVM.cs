using LiveCharts;
using LiveCharts.Wpf;
using Vogelscheuche_Bib;

namespace WPF.ViewModel
{
    class WeeklyStatisticsVM : Utilities.ViewModelBase
    {
        //Konstruktor
        public WeeklyStatisticsVM()
        {
            // Beim Erstellen des ViewModel werden die Daten für das Kreis- und Balkendiagramm geladen
            LoadWeeklyPieData();
            LoadWeeklyBarStatisticData();
        }

        // Eigenschaft für das Kreisdiagramm
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

        private void LoadWeeklyPieData()
        {
            // Statistikdaten für das Kreisdiagramm abrufen
            Dictionary<string, int> birdStatistics = StatisticCalculator.PrintBirdStatisticsLast7Days();

            // SerieCollection für das Kreisdiagramm erstellen
            BirdPieSeriesWeekly = new SeriesCollection();
            foreach (string day in birdStatistics.Keys)
            {
                // Serie für jeden Tag erstellen
                PieSeries series = new PieSeries
                {
                    Title = day,
                    Values = new ChartValues<int> { birdStatistics[day] },
                    DataLabels = true,
                    // Labels für jedes Segment des Diagramms formatieren
                    LabelPoint = chartPoint => $"{chartPoint.Y} {(chartPoint.Y == 1 ? "Vogel" : "Vögel")}"

                };

                // Serie zur SerieCollection hinzufügen
                BirdPieSeriesWeekly.Add(series);
            }
        }

        // Eigenschaft für das Balkendiagramm
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

        public void LoadWeeklyBarStatisticData()
        {
            // Statistikdaten für das Balkendiagramm abrufen
            Dictionary<string, int> weeklyBirdBarStatistic = StatisticCalculator.PrintMostCommonSpeciesLast7Days();
            WeeklyBirdBarSeries = new SeriesCollection();

            foreach (string species in weeklyBirdBarStatistic.Keys)
            {
                // Serie für jede Vogelart erstellen
                ColumnSeries series = new ColumnSeries
                {
                    Title = species,
                    Values = new ChartValues<int> { weeklyBirdBarStatistic[species] }
                };

                // Serie zur SerieCollection hinzufügen
                WeeklyBirdBarSeries.Add(series);
            }

            // Labels auf der X-Achse aktualisieren, um den Vogelarten zu entsprechen
            Labels = weeklyBirdBarStatistic.Keys.ToArray();

        }

        // Eigenschaft für die Labels auf der X-Achse des Balkendiagramms
        public string[] Labels { get; set; }
        // Funktion zum Formatieren der Werte auf der Y-Achse des Balkendiagramms
        public Func<double, string> Formatter { get; set; }
    }
}
