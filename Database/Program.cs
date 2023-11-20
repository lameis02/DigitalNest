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
            //SqlConnection Connection = new SqlConnection(@"Server=RANGORX\SQLEXPRESS01;Database=Vogelsammlung;User Id=RangoRX\morit;Password=gfb;");
            SqlConnection Connection = new SqlConnection("Data Source=RANGORX\\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
            Connection.Open();
            string query = "Insert Into Vogelsammlung (Id,Vogel,Art,Datum,Ort) values (@Id,@Vogel,@Art,@Datum,@Ort)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", "");
            command.Parameters.AddWithValue("@Vogel", "Bird.Vogel");
            command.Parameters.AddWithValue("@Art", "Bird.Art");
            command.Parameters.AddWithValue("@Datum", "Bird.Datum");
            command.Parameters.AddWithValue("@Ort", "Bird.Ort");
            command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}
