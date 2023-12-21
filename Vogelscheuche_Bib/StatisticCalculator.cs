using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Vogelscheuche_Bib
{
    internal class StatisticCalculator
    {

        public static void PrintBirdStatistics()
        {
            //im string wird der Wochentag und im int die Anzahlder Vögel gespeichert
            Dictionary<string, int> birdCountPerDay = new Dictionary<string, int>();


            //Verbindung zur Datenbank
            using (SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;"))
            {
                //Verbindung zur Datenbank wird geöffnet
                Connection.Open();
                string query = "SELECT Datum FROM Vogelsammlung"; //SQL Abfrage-->Datumangaben der Vögel 
                SqlCommand command = new SqlCommand(query, Connection);

                using (SqlDataReader reader = command.ExecuteReader())//der Reader wird erstellt um die Ergebnisse der SQL Abfrage zu lesen
                {
                    while (reader.Read()) //--> einmal durch die Ergbenisse
                    {
                        DateTime date = reader.GetDateTime(0); // das aktuelle Datum des Vogels wird aus der Datenbank aufgerufen
                        string dayOfWeek = date.ToString("dddd"); //der Wochentag-->string

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
            }
        
        // Gib die Statistiken aus
        Console.WriteLine("Statistik der Vögel pro Wochentag:");
            foreach (var entry in birdCountPerDay)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} Vögel");
            }
}

public static void Main()
{
    // Methode für die Vogelstatistiken werden aufgerufen auf
    PrintBirdStatistics();

    //Warte auf Benutzereingabe, um das Konsolenfenster offen zu halten
    Console.ReadKey();
}
    }
}

           






