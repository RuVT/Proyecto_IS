using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQL_ClassLibrary
{
    public class SQL_manager
    {
        private static SqlConnection Connection;
        private static bool CloseConnectionAfterAction { get; set; }

        public static void Init(string conection_string)
        {
            CloseConnectionAfterAction = true;
            Connection = tryConections();
        }
        public static void openConection()
        {
            if (Connection != null)
            {
                if(Connection.State!=ConnectionState.Open)
                    Connection.Open();
            }
        }
        public static void closeConection()
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open && CloseConnectionAfterAction)
                    Connection.Close();
            }
        }
        public static SqlConnection getConection()
        {
            return Connection;
        }
        public static void executeCommand(SqlCommand command)
        {
            openConection();
            command.Connection = Connection;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception) { }
            closeConection();
        }
        public static void executeCommand(string query)
        {
            SqlCommand command=new SqlCommand(query);
            executeCommand(command);
        }
        public static DataTable readTable(SqlCommand command)
        {
            DataTable table=new DataTable();
            openConection();
            command.Connection=Connection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            try
            {
                adapter.Fill(table);
            }
            catch (Exception) { return null; }
            closeConection();
            return table;
        }
        public static DataTable readTable(string query)
        {
            SqlCommand command = new SqlCommand(query);
            return readTable(command);
        }
        private static SqlConnection tryConections()
        {
            SqlConnection testCon=new SqlConnection();
            string [] connectionString = System.IO.File.ReadAllLines("cadena_conexiones");
            foreach (string con in connectionString)
            {
                testCon.ConnectionString=con;
                try
                {
                    testCon.Open();
                    if (testCon.State == ConnectionState.Open)
                    {
                        testCon.Close();
                        return testCon;
                    }
                }
                catch (Exception) { }
            }
            return null;
        }       

    }
}