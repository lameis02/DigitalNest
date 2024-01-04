﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
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
            /*DeleteAll("");
            Add("sparrow1");
            Select(");");
            Console.ReadLine();*/



            Bird sparrow1 = new Bird //keine 10 Charaktere überschreiten. Laut Moritz
            {
                Name = "Spatz",
                Species = "Sperling",
                Date = DateTime.Parse("2023-01-01"),
                Location = "Park",
                ImagePath = @"C:\Pfad\Zum\Bild1.jpg",
                IsFavorite = "nein"
            };
            Bird eagle1 = new Bird
            {
                Name = "Adler",
                Species = "Greifvogel",
                Date = DateTime.Parse("2023-02-01"),
                Location = "Berg",
                ImagePath = @"/Users/hilalkrtgl/Documents/3.Semester Ingenieurinformatik/Programmier Projekt/b-vogelscheuche/Bilder/Adler.jpg",
                IsFavorite = "ja"
            };

            Bird owl1 = new Bird
            {
                Name = "Eule",
                Species = "Eulenart",
                Date = DateTime.Parse("2023-03-01"),
                Location = "Wald",
                ImagePath = @"/Users/hilalkrtgl/Documents/3.Semester Ingenieurinformatik/Programmier Projekt/b-vogelscheuche/Bilder/Eule.jpg",
                IsFavorite = "nein"
            };
            Bird sparrow2 = new Bird
            {
                Name = "Spatz",
                Species = "Sperling",
                Date = DateTime.Parse("2023-04-01"),
                Location = "Garten",
                ImagePath = @"/Users/hilalkrtgl/Documents/3.Semester Ingenieurinformatik/Programmier Projekt/b-vogelscheuche/Bilder/Spatz2.jpg",
                IsFavorite = "ja"
            };

            Bird pigeon1 = new Bird
            {
                Name = "Taube",
                Species = "Taube",
                Date = DateTime.Parse("2023-05-01"),
                Location = "Stadt",
                ImagePath = @"/Users/hilalkrtgl/Documents/3.Semester Ingenieurinformatik/Programmier Projekt/b-vogelscheuche/Bilder/Taube.jpg",
                IsFavorite = "nein"
            };

            Bird sparrow3 = new Bird
            {
                Name = "Spatz",
                Species = "Sperling",
                Date = DateTime.Parse("2023-06-01"),
                Location = "Wiese",
                ImagePath = @"/Users/hilalkrtgl/Documents/3.Semester Ingenieurinformatik/Programmier Projekt/b-vogelscheuche/Bilder/Spatz3.jpg",
                IsFavorite = "nein"
            };



            //DeleteAll();
            Add(sparrow1);
            Add(pigeon1);
            Console.ReadLine();
            //Select("");
            //Console.WriteLine($"Der neu eingefügte Vogel hat die ID: {sparrow1.ID}");
            Console.ReadLine();

        }

            public static void Add(Bird bird, int i = -1) // If a row was deleted the next 'insert' is being inserted into the previous deleted row with the remembered Id
            {

                if (i >= 0)
                {
                    SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;");
                    Connection.Open();

                    string setIdentityInsertOn = "SET IDENTITY_INSERT Vogelsammlung ON";
                    SqlCommand commandOn = new SqlCommand(setIdentityInsertOn, Connection);
                    commandOn.ExecuteNonQuery();

                    string query = "Insert Into Vogelsammlung (Id,Vogel,Art,Datum,Ort,Bild,Favorit) values (@Id,@Vogel,@Art,@Datum,@Ort,@Bild,@Favorit)";
                    SqlCommand command = new SqlCommand(query, Connection);
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@Vogel", bird.Name);
                    command.Parameters.AddWithValue("@Art", bird.Species);
                    command.Parameters.AddWithValue("@Datum", bird.Date);
                    command.Parameters.AddWithValue("@Ort", bird.Location);
                    byte[] bytes = File.ReadAllBytes(@"/Users/hilalkrtgl/Documents/WhatsApp Image 2023-12-06 at 09.44.53.jpeg");
                    command.Parameters.AddWithValue("@Bild", bytes);
                    command.Parameters.AddWithValue("@Favorit", bird.Location);
                    command.ExecuteNonQuery();

                    string setIdentityInsertOff = "SET IDENTITY_INSERT Vogelsammlung OFF";
                    SqlCommand commandOff = new SqlCommand(setIdentityInsertOff, Connection);
                    commandOff.ExecuteNonQuery();

                    Connection.Close();
                }
                else
                {
                    SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;");
                    Connection.Open();
                    string query = "Insert Into Vogelsammlung (Vogel,Art,Datum,Ort,Bild,Favorit) values (@Vogel,@Art,@Datum,@Ort,@Bild,@Favorit)";
                    SqlCommand command = new SqlCommand(query, Connection);
                    //command.Parameters.AddWithValue("@Id","");
                    command.Parameters.AddWithValue("@Vogel", bird.Name);
                    command.Parameters.AddWithValue("@Art", bird.Species);
                    command.Parameters.AddWithValue("@Datum", bird.Date);
                    command.Parameters.AddWithValue("@Ort", bird.Location);
                    byte[] bytes = File.ReadAllBytes(@"/Users/hilalkrtgl/Documents/WhatsApp Image 2023-12-06 at 09.44.53.jpeg");
                    command.Parameters.AddWithValue("@Bild", bytes);
                    command.Parameters.AddWithValue("@Favorit", bird.IsFavorite);
                    command.ExecuteNonQuery();
                    Connection.Close();
                }
            }

            public static void Delete(Bird bird)
            {
                SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;");
                Connection.Open();
                string query = "Delete Vogelsammlung where Id=@Id";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Id", "3");
                command.ExecuteNonQuery();
                Connection.Close();
            }
            public static void DeleteAll(Bird bird)
            {
                SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;");
                Connection.Open();
                string query = "Delete FROM Vogelsammlung";
                SqlCommand command = new SqlCommand(query, Connection);
                command.ExecuteNonQuery();
                string resetIdentity = "DBCC CHECKIDENT('Vogelsammlung', RESEED, 0)";
                SqlCommand reset = new SqlCommand(resetIdentity, Connection);
                reset.ExecuteNonQuery();
                Connection.Close();
            }
            public static void Select(Bird bird)
            {
                SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;");
                Connection.Open();
                SqlCommand command = new SqlCommand("select * from Vogelsammlung", Connection);
                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader.GetValue(i));
                    }
                }
                Connection.Close();
            }

            public static void ShowPicture()
            {
                SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;");
                Connection.Open();
                SqlDataAdapter dAdapter = new SqlDataAdapter(new SqlCommand("SELECT Photo FROM Image", Connection));
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet);
                if (dSet.Tables.Count > 0)
                { }
                Byte[] data = new Byte[0];
                data = (Byte[])(dSet.Tables[0].Rows[0]["pic"]);
                MemoryStream mem = new MemoryStream(data);
                //yourPictureBox.Image = Image.FromStream(mem);  // yourpicture box ist in forms dann ein feld
                Connection.Close();
            }
            public static void Override(Bird bird)
            {
                SqlConnection Connection = new SqlConnection("Server=localhost,1433;Database=Vogeldatenbank;User Id=SA;Password=YourStrong!Passw0rd;");
                Connection.Open();
                string query = "Update Vogelsammlung SET Id = @Id, Vogel=@Vogel, Art=@Art, Datum=@Datum,Ort=@Ort, Favorit=@Favorit where Id = @Id ";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Id", bird.ID);
                command.Parameters.AddWithValue("@Vogel", bird.Name);
                command.Parameters.AddWithValue("@Art", bird.Species);
                command.Parameters.AddWithValue("@Datum", bird.Date);
                command.Parameters.AddWithValue("@Ort", bird.Location);
                command.Parameters.AddWithValue("@Favorit", bird.IsFavorite);
                command.ExecuteNonQuery();
                Connection.Close();
            }
            public static void Show(Bird bird)
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=RANGORX\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
                Connection.Open();
                SqlCommand command = new SqlCommand("Select * from Vogelsammlung", Connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                //dataGridView1.DataSource = dt;   //Data grid view 1 ist ein Feld in Forms
                Connection.Close();
            }
        }
    

    
}
