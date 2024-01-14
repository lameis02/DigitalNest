using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Database
{
    public class Program
    {


        static void Main(string[] args)
        {


            Bird sparrow1 = new Bird //keine 10 Charaktere überschreiten. Laut Moritz
            {
                Species = "Sperling",
                Date = DateTime.Parse("2023-01-12"),
                Location = "Park",
                ImagePath = @"C:\Users\o364b\OneDrive - Dr. Daniel Büttner\WiSe_23_24\Dall-E\Icon.png",
                IsFavorite = false
            };
            Bird eagle1 = new Bird
            {
                Species = "Greifvogel",
                Date = DateTime.Parse("2023-02-01"),
                Location = "Berg",
                ImagePath = @"C:\Users\o364b\OneDrive - Dr. Daniel Büttner\WiSe_23_24\Dall-E\Icon.png",
                IsFavorite = true
            };

            Bird owl1 = new Bird
            {
                Species = "Eulenart",
                Date = DateTime.Parse("2023-01-10"),
                Location = "Wald",
                ImagePath = @"C:\Users\o364b\OneDrive - Dr. Daniel Büttner\WiSe_23_24\Dall-E\Icon.png",
                IsFavorite = false
            };
            Bird sparrow2 = new Bird
            {
                Species = "Sperling",
                Date = DateTime.Parse("2023-01-11"),
                Location = "Garten",
                ImagePath = @"C:\Users\o364b\OneDrive - Dr. Daniel Büttner\WiSe_23_24\Dall-E\Icon.png",
                IsFavorite = true
            };

            Bird pigeon1 = new Bird
            {
                Species = "Taube",
                Date = DateTime.Parse("2023-01-13"),
                Location = "Stadt",
                ImagePath = @"C:\Users\o364b\OneDrive - Dr. Daniel Büttner\WiSe_23_24\Dall-E\Icon.png",
                IsFavorite = false
            };

            Bird sparrow3 = new Bird
            {
                Species = "Sperling",
                Date = DateTime.Parse("2023-01-10"),
                Location = "Wiese",
                ImagePath = @"C:\Users\o364b\OneDrive - Dr. Daniel Büttner\WiSe_23_24\Dall-E\Icon.png",
                IsFavorite = false
            };

            DeleteAll();
            Add(sparrow2);
            Add(sparrow3);
            Add(sparrow1);
            Add(owl1);
            Add(pigeon1);
            // Select();
            Console.ReadLine();

        }

        public static void Add(Bird bird, int i = -1) // If a row was deleted the next 'insert' is being inserted into the previous deleted row with the remembered Id
        {

            if (i >= 0)
            {
                SqlConnection Connection = new SqlConnection(OpenConnection());
                Connection.Open();

                string setIdentityInsertOn = "SET IDENTITY_INSERT Vogelsammlung ON";
                SqlCommand commandOn = new SqlCommand(setIdentityInsertOn, Connection);
                commandOn.ExecuteNonQuery();

                string query = QueryAddMethode();
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Id", i);
                command.Parameters.AddWithValue("@Art", bird.Species);
                command.Parameters.AddWithValue("@Datum", bird.Date);
                command.Parameters.AddWithValue("@Ort", bird.Location);
                byte[] bytes = File.ReadAllBytes(bird.ImagePath);
                command.Parameters.AddWithValue("@Bild", bytes);
                command.Parameters.AddWithValue("@Favorit", bird.IsFavorite);
                command.ExecuteNonQuery();

                string setIdentityInsertOff = "SET IDENTITY_INSERT Vogelsammlung OFF";
                SqlCommand commandOff = new SqlCommand(setIdentityInsertOff, Connection);
                commandOff.ExecuteNonQuery();

                Connection.Close();
            }
            else
            {
                SqlConnection Connection = new SqlConnection(OpenConnection());
                Connection.Open();
                string query = QueryAddMethode();
                SqlCommand command = new SqlCommand(query, Connection);
                //command.Parameters.AddWithValue("@Id","");
                command.Parameters.AddWithValue("@Art", bird.Species);
                command.Parameters.AddWithValue("@Datum", bird.Date);
                command.Parameters.AddWithValue("@Ort", bird.Location);
                byte[] bytes = File.ReadAllBytes(bird.ImagePath);
                command.Parameters.AddWithValue("@Bild", bytes);
                command.Parameters.AddWithValue("@Favorit", bird.IsFavorite);
                command.ExecuteNonQuery();
                Connection.Close();
            }
        }

        public static void Delete(int i)
        {
            SqlConnection Connection = new SqlConnection(OpenConnection());
            Connection.Open();
            string query = "Delete Vogelsammlung where Id=@Id";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", i);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        public static void DeleteAll()
        {
            SqlConnection Connection = new SqlConnection(OpenConnection());
            Connection.Open();
            string query = "Delete FROM Vogelsammlung";
            SqlCommand command = new SqlCommand(query, Connection);
            command.ExecuteNonQuery();
            string resetIdentity = "DBCC CHECKIDENT('Vogelsammlung', RESEED, 0)";
            SqlCommand reset = new SqlCommand(resetIdentity, Connection);
            reset.ExecuteNonQuery();
            Connection.Close();
        }
        public static List<byte[]> Select()
        {
            SqlConnection Connection = new SqlConnection(OpenConnection());
            Connection.Open();
            SqlCommand command = new SqlCommand("select * from Vogelsammlung", Connection);
            SqlDataReader reader = null;
            reader = command.ExecuteReader();
            List<byte[]> b = new List<byte[]>();
            while (reader.Read())
            {

                byte[] path = (byte[])reader["Bild"];
                b.Add(path);
                //for (int i = 0; i < reader.FieldCount; i++)
                //    {
                //        Console.WriteLine(reader.GetValue(i));
                //    }
            }
            Connection.Close();
            return b;
        }

        //public static void ShowPicture()
        //{
        //    SqlConnection Connection = new SqlConnection(OpenConnection());
        //    Connection.Open();
        //    SqlDataAdapter dAdapter = new SqlDataAdapter(new SqlCommand("SELECT Photo FROM Image", Connection));
        //    DataSet dSet = new DataSet();
        //    dAdapter.Fill(dSet);
        //    if (dSet.Tables.Count > 0)
        //    { }
        //    Byte[] data = new Byte[0];
        //    data = (Byte[])(dSet.Tables[0].Rows[0]["pic"]);
        //    MemoryStream mem = new MemoryStream(data);
        //    //yourPictureBox.Image = Image.FromStream(mem);  // yourpicture box ist in forms dann ein feld
        //    Connection.Close();
        //}
        public static void Override(Bird bird)
        {
            SqlConnection Connection = new SqlConnection(OpenConnection());
            Connection.Open();
            string query = "Update Vogelsammlung SET Id = @Id, Art=@Art, Datum=@Datum,Ort=@Ort, Favorit=@Favorit where Id = @Id ";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", bird.ID);
            command.Parameters.AddWithValue("@Art", bird.Species);
            command.Parameters.AddWithValue("@Datum", bird.Date);
            command.Parameters.AddWithValue("@Ort", bird.Location);
            command.Parameters.AddWithValue("@Favorit", bird.IsFavorite);
            command.ExecuteNonQuery();
            Connection.Close();
        }
        public static List<byte[]> SelectPlace(string place)
        {
            SqlConnection Connection = new SqlConnection(OpenConnection());
            Connection.Open();
            SqlCommand command = new SqlCommand("select * from Vogelsammlung", Connection);
            SqlDataReader reader = null;
            command.Parameters.AddWithValue("@Ort", place);
            reader = command.ExecuteReader();
            List<byte[]> b = new List<byte[]>();
            while (reader.Read())
            {
                byte[] path = (byte[])reader["Bild"];
                b.Add(path);
                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    Console.WriteLine(reader.GetValue(i));
                //}
            }
            Connection.Close();
            return b;
        }
        public static List<byte[]> SelectDate(string date)
        {
            SqlConnection Connection = new SqlConnection(OpenConnection());
            Connection.Open();
            SqlCommand command = new SqlCommand("select * from Vogelsammlung where Datum=@Datum", Connection);
            SqlDataReader reader = null;
            command.Parameters.AddWithValue("@Ort", date);
            reader = command.ExecuteReader();
            List<byte[]> b = new List<byte[]>();
            while (reader.Read())
            {
                byte[] path = (byte[])reader["Bild"];
                b.Add(path);
                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    Console.WriteLine(reader.GetValue(i));
                //}
            }
            Connection.Close();
            return b;
        }
        public static List<byte[]> SelectFavorite(bool fav)
        {
            SqlConnection Connection = new SqlConnection(OpenConnection());
            Connection.Open();
            SqlCommand command = new SqlCommand("select * from Vogelsammlung where Favorit=@Favorit", Connection);
            SqlDataReader reader = null;
            command.Parameters.AddWithValue("@Favorit", fav);
            reader = command.ExecuteReader();
            List<byte[]> b = new List<byte[]>();
            while (reader.Read())
            {
                byte[] path = (byte[])reader["Bild"];
                b.Add(path);
                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    Console.WriteLine(reader.GetValue(i));
                //}
            }
            Connection.Close();
            return b;
        }
        public static string OpenConnection()
        {
            string x = "Server=localhost,1433;Database=Vogeldatenbank;User ID=SA;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";
            return x;
        }
        public static string QueryAddMethode()
        {
            string x = "Insert Into Vogelsammlung (Art,Datum,Ort,Bild,Favorit) values (@Art,@Datum,@Ort,@Bild,@Favorit)";
            return x;
        }
    }

}
