using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Database;
using Microsoft.Data.SqlClient;
using System.Data;



namespace Vogelscheuche_Bib
{
  
    public class StatisticCalculator
    {
        /*>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                         Die erste Methode: Vögel pro Wochentag sollen ausgegeben werden
        >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/

        public static Dictionary<string,int>  PrintBirdStatisticsAllTime() //Laura aus dieser Methode kriegst du ein Dictionary welches dir die Vögel pro Wochentag ausgibt
        {
            //im string wird der Wochentag und im int die Anzahlder Vögel gespeichert
            Dictionary<string, int> birdCountPerDay = new Dictionary<string, int>();


            //Verbindung zur Datenbank
            using (SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"))
            {
                //Verbindung zur Datenbank wird geöffnet
                Connection.Open();
                string query = "SELECT Datum FROM Vogelsammlung"; //SQL Abfrage-->Datumangaben der Vögel 
                SqlCommand command = new SqlCommand(query, Connection);

                using (SqlDataReader reader = command.ExecuteReader())//der Reader wird erstellt um die Ergebnisse der SQL Abfrage zu lesen
                {
                    while (reader.Read()) //--> einmal durch die Ergbenisse
                    {
                        if (DateTime.TryParse(reader.GetString(0), out DateTime date))
                        {
                            string dayOfWeek = date.ToString("dddd");
                            if (birdCountPerDay.ContainsKey(dayOfWeek))
                            {
                                birdCountPerDay[dayOfWeek]++;
                            }
                            else
                            {
                                birdCountPerDay.Add(dayOfWeek, 1);
                            }
                        }
                        else
                        {
                            // Handle the case where the string could not be parsed as a DateTime
                            Console.WriteLine("Invalid date format for record.");
                        }
                        
                        
                    }
                }
            }

            // Gib die Statistiken aus
            Console.WriteLine("Statistik der Vögel pro Wochentag:");
            foreach (var entry in birdCountPerDay)
            {
                if ( entry.Value ==1)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value} Vogel");
                }
                else
                Console.WriteLine($"{entry.Key}: {entry.Value} Vögel");
            }
            return birdCountPerDay;
        }

        /*>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                         Die zweite Methode: Welche Vogelart kam am meisten vor?
        >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/

        public static Dictionary<string, int> PrintMostCommonSpeciesAllTime()
        {
            // speciesCount werden die Anzahl der vorkommenden Vogelarten gespeichert
            Dictionary<string, int> speciesCount = new Dictionary<string, int>();

            using (SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"))
            {
                Connection.Open();
                //SQL Abfrage um alle Vogelarten+ihre Anzahl abzurufen
                string query = "SELECT Art FROM Vogelsammlung";//Aufruf aus der Tabelle der Datenbank
                SqlCommand command = new SqlCommand(query, Connection);

                using (SqlDataReader reader = command.ExecuteReader()) //reader wird ertsellt um Ergebnisse der SQL-Abfrage zu lesen.
                {
                    while (reader.Read()) //hier werden die Ergebnisse des Readers durchlaufen
                    {
                        if (!reader.IsDBNull(0))
                        {
                            string species = reader.GetString(0); // Der Name der Vogelart wird aus der ersten Spalte (Index 0) gelesen.
                            if (speciesCount.ContainsKey(species)) //Hier wird überprüft, ob die Vogelart bereits im Dictionary enthalten ist
                            {
                                speciesCount[species]++;//Wenn die Vogelart bereits vorhanden ist, wird die Anzahl aktualisiert.
                            }
                            else
                            {
                                speciesCount.Add(species, 1);//Wenn die Vogelart nicht vorhanden ist, wird sie dem Dictionary hinzugefügt.
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nWelche Vogelart kam in der Woche am meisten vor?:");
            var mostCommonSpecies = speciesCount.OrderByDescending(x => x.Value).FirstOrDefault(); //hier wird sortiert in absteigende Reihenfolge und wählt das mit den meisten. (Mit Firstdefault wird das häufigste also das an der ersten Stelle gewählt
            if (mostCommonSpecies.Key != null && mostCommonSpecies.Value == 1)
            {
                Console.WriteLine($"{mostCommonSpecies.Key}: {mostCommonSpecies.Value} Vogel");
            }
            else 

                Console.WriteLine($"{mostCommonSpecies.Key}: {mostCommonSpecies.Value} Vögel");
                string rückgabe = $"{mostCommonSpecies.Value}";

            return speciesCount;
        }
        


        /*>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                         Die dritte Methode: Wieviele Vögel kamen an welchem Wochentag wie oft vor? Nur aktuelle Woche
        >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/

        public static Dictionary<string,int>PrintBirdStatisticsLast7Days() //Laura aus dieser Methode kriegst du ein Dictionary welches dir die Vögel pro Wochentag ausgibt (letzten7Tage)
        {
            Dictionary<string, int> birdCountPerDay = new Dictionary<string, int>();

            try
            {
                //Holen Sie die Daten für die letzten 7 Tage SelectWeek-Methode
                List<List<Bird>> weekBirds = Program.SelectWeek();

                for (int i = 0; i < 7; i++)
                {
                    foreach (var bird in weekBirds[i])
                    {
                        string dayOfWeek = bird.Date.ToString("dddd");
                        if (birdCountPerDay.ContainsKey(dayOfWeek))
                        {
                            birdCountPerDay[dayOfWeek]++;
                        }
                        else
                        {
                            birdCountPerDay.Add(dayOfWeek, 1);
                        }
                    }
                }

                Console.WriteLine("Statistik der Vögel pro Wochentag (Letzte 7 Tage):");
                foreach (var entry in birdCountPerDay)
                {
                    if (entry.Value == 1)
                    {
                        Console.WriteLine($"{entry.Key}: {entry.Value} Vogel");
                    }
                    else 
                    Console.WriteLine($"{entry.Key}: {entry.Value} Vögel");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message + " " + ex.Source);
            }
            return birdCountPerDay;
        }
        /*>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                         Die vierte Methode:  Welche Vogelart kam in der Woche am meisten vor? Nur aktuelle Woche
        >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
        public static Dictionary<string, int> PrintMostCommonSpeciesLast7Days() //Laura aus dieser Methode kriegst du ein Dictionary welches dir die Vogelart und Häufigkeit ausgibt
        {
            Dictionary<string, int> speciesCount = new Dictionary<string, int>();

            try
            {
                List<List<Bird>> weekBirds = Program.SelectWeek();

                foreach (var dayBirds in weekBirds)
                {
                    foreach (var bird in dayBirds)
                    {
                        if (!string.IsNullOrEmpty(bird.Species))
                        {
                            string species = bird.Species;
                            if (speciesCount.ContainsKey(species))
                            {
                                speciesCount[species]++;
                            }
                            else
                            {
                                speciesCount.Add(species, 1);
                            }
                        }
                    }
                }

                Console.WriteLine("\nWelche Vogelart kam am häufigsten vor? (Letzte 7 Tage):");
                var mostCommonSpecies = speciesCount.OrderByDescending(x => x.Value).FirstOrDefault();
                if (mostCommonSpecies.Key != null && mostCommonSpecies.Value == 1)
                {
                    Console.WriteLine($"{mostCommonSpecies.Key}: {mostCommonSpecies.Value} Vogel");
                }
                else
                    Console.WriteLine($"{mostCommonSpecies.Key}: {mostCommonSpecies.Value} Vögel");
                return speciesCount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message + " " + ex.Source);
            }
            return speciesCount;

        }


        public static void Main()
        {
            try
            {
                // Methode für die Vogelstatistiken werden aufgerufen 
                PrintBirdStatisticsAllTime();
                PrintMostCommonSpeciesAllTime();
                PrintBirdStatisticsLast7Days();
                PrintMostCommonSpeciesLast7Days();


          
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message + " " + ex.Source);

            }
            

        }
    }
}

