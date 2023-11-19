using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Add("Taube");
        }
        public static void Add(string Bird) //sollte vielleicht ein Objekt werden mit Eigenschaften
        {
            SqlConnection Connection = new SqlConnection(@"Server=RANGORX\SQLEXPRESS01;Database=myDataBase;User Id=myUsername;Password=myPassword;");
            Connection.Open();
            string query = "Insert Into Vogelsammlung (Id,Vogel,Art,Datum,Ort) values (@Id,@Vogel,@Art,@Datum,@Ort)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", "max.Id+1");
            command.Parameters.AddWithValue("@Vogel", "Bird.Vogel");
            command.Parameters.AddWithValue("@Art", "Bird.Art");
            command.Parameters.AddWithValue("@Datum", "Bird.Datum");
            command.Parameters.AddWithValue("@Ort", "Bird.Ort");
            command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}
