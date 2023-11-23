using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using System.Data;

namespace Database
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            //Add("Taube");
            Delete("TAube");
            Select("Taube");
            Console.ReadLine();
        }
        public static void Add(string Bird) //sollte vielleicht ein Objekt werden mit Eigenschaften
        {
            //SqlConnection Connection = new SqlConnection(@"Server=RANGORX\SQLEXPRESS01;Database=Vogelsammlung;User Id=RangoRX\morit;Password=gfb;");
            SqlConnection Connection = new SqlConnection("Data Source=RANGORX\\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
            Connection.Open();
            string query = "Insert Into Vogelsammlung (Id,Vogel,Art,Datum,Ort) values (@Id,@Vogel,@Art,@Datum,@Ort)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", "6");
            command.Parameters.AddWithValue("@Vogel", "Vogel");
            command.Parameters.AddWithValue("@Art", "Art");
            command.Parameters.AddWithValue("@Datum", "Datum");
            command.Parameters.AddWithValue("@Ort", "Ort");
            command.Parameters.AddWithValue("@Favorit", "1");
            command.ExecuteNonQuery();
            Connection.Close();
        }
        public static void Delete(string Bird)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=RANGORX\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
            Connection.Open();
            string query = "Delete Vogelsammlung where Id=@Id";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", "7");
            command.ExecuteNonQuery ();
            Connection.Close();
        }
        public static void Select(string Bird)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=RANGORX\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
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
        }
        public static void Override (string Bird) 
        {
            Delete(Bird);
            Add(Bird);
        }
        public static void Show (string Bird)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=RANGORX\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
            Connection.Open();
            SqlCommand command = new SqlCommand("Select * from Vogelsammlung", Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();  
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //dataGridView1.DataSource = dt;   //Data grid view 1 ist ein Feld in Forms
        }
        //public static void Select(string Bird)
        //{
        //    SqlConnection Connection = new SqlConnection(@"Data Source=RANGORX\SQLEXPRESS01;Initial Catalog=Vogelsammlung;Integrated Security=True;Pooling=False;Encrypt=False;");
        //    Connection.Open();
        //    SqlCommand command = new SqlCommand()
        //}
    }
}
