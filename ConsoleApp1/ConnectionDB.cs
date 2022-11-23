using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace ConsoleApp1
{

    internal class ConnectionDB
    {
        SqlConnectionStringBuilder stringConnection;
        string cadena;
        public SqlConnection connection = new SqlConnection();
        public SqlCommand cmd;
        
        public ConnectionDB()
        {
            stringConnection = new SqlConnectionStringBuilder();
            stringConnection.DataSource = "localhost\\SQLEXPRESS";
            stringConnection.UserID = "edson";
            stringConnection.IntegratedSecurity = false;
            stringConnection.Password = "root";
            stringConnection.InitialCatalog = "school";
            cadena = stringConnection.ToString();
            connection.ConnectionString = cadena;
            
            cmd = new SqlCommand();
            cmd.Connection = connection;
        }
        public bool Open()
        {
            try 
            {
                connection.Open();
                Console.WriteLine("Connection Open ");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public void executeQuery(string query)
        {
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        public string viewData(string query)
        {
            SqlDataReader reader;
            
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    
                    Console.WriteLine(reader.GetName(i) + ":" + reader[i]);
                }
                
            }
            reader.Close();
            return "End";
            
        }
        public void Close()
        {
            connection.Close();
        }
    }
}
