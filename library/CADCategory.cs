using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool Read(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = "SELECT code, name, price, amount FROM Products WHERE code = @Code";
                SqlCommand command = new SqlCommand(query, c);

                command.Parameters.AddWithValue("@Code", en.Code);

                SqlDataReader reader = command.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el producto: " + ex.Message);
                return false;
            }
            finally { c.Close(); }
        }

        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            using (SqlConnection connection = new SqlConnection(constring))
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
