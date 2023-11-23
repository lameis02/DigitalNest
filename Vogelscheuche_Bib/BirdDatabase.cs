using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Vogelscheuche_Bib
{
    //public object SqlConnection { get; private set; }
    public class BirdDatabase
    {
        public static void Add (string Bird) //sollte vielleicht ein Objekt werden mit Eigenschaften
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=RANGORX\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False");
            Connection.Open ();
            string query = "Insert Into Vogelsammlung (Id,Vogel,Art,Datum,Ort) values (@Id,@Vogel,@Art,@Datum,@Ort)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", "max.Id+1");
            command.Parameters.AddWithValue("@Vogel", "Bird.Vogel");
            command.Parameters.AddWithValue("@Art", "Bird.Art");
            command.Parameters.AddWithValue("@Datum", "Bird.Datum");
            command.Parameters.AddWithValue("@Ort", "Bird.Ort");
            command.ExecuteNonQuery();
            Connection.Close ();
        }
        public static void Delete (string Bird) 
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=RANGORX\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
            Connection.Open();
            string query = "Delete Vogelsammlung Where Bird";
            SqlCommand command = new SqlCommand(query, Connection);
        }
        public static string Get (string Bird) 
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=RANGORX\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
            Connection.Open();
            SqlCommand command = new SqlCommand("select * from Vogelsammlung", Connection);
            SqlDataReader reader = null;
            reader = command.ExecuteReader();
            string s;
            while (reader.Read()) 
            {
                s = reader["Art"].ToString();
            }
            return s;
        }
    }
    
}
  