using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADCategory
    {
        private string _connectionString;

        public CADCategory()
        {
            _connectionString = "data source=(LocalDB)\\MSSQLLocalDB;IntegratedSecurity=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf";
        }

        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Categories";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string name = reader["Name"].ToString();
                        ENCategory category = new ENCategory(id, name);
                        categories.Add(category);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error en la operación de lectura de categorías: {0}", ex.Message);
                }
            }

            return categories;
        }
    }
}
