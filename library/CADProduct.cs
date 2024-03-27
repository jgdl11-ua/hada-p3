using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            constring = "data source=(LocalDB)\\MSSQLLocalDB;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf";
        }

        public bool Create(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Products (code,name,amount,price,category,creationDate) " +
                    "VALUES (@Code, @Name, @Amount, @Price, @Category, @CreationDate)", c);
                command.Parameters.AddWithValue("@Code", en.Code);
                command.Parameters.AddWithValue("@Name", en.Name);
                command.Parameters.AddWithValue("@Amount", en.Amount);
                command.Parameters.AddWithValue("@Price", en.Price);
                command.Parameters.AddWithValue("@Category", en.Category);
                command.Parameters.AddWithValue("@CreationDate", en.CreationDate);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("La operación de producto ha fallado. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }
        public bool Update(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {

                c.Open();
                SqlCommand command = new SqlCommand("UPDATE Products SET name = @Name, amount = @Amount, price = @Price, category = @Category, creationDate = @CreationDate WHERE code = @Code", c);
                command.Parameters.AddWithValue("@Code", en.Code);
                command.Parameters.AddWithValue("@Name", en.Name);
                command.Parameters.AddWithValue("@Amount", en.Amount);
                command.Parameters.AddWithValue("@Price", en.Price);
                command.Parameters.AddWithValue("@Category", en.Category);
                command.Parameters.AddWithValue("@CreationDate", en.CreationDate);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("La operación de producto ha fallado. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }
        public bool Delete(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Products WHERE code = @Code", c);
                command.Parameters.AddWithValue("@Code", en.Code);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("La operación de producto ha fallado. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }
        public bool Read(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE code = @Code", c);
                command.Parameters.AddWithValue("@Code", en.Code);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    en.Code = reader["code"].ToString();
                    en.Name = reader["name"].ToString();
                    en.Amount = (int)reader["amount"];
                    en.Price = float.Parse(reader["price"].ToString());
                    en.Category = (int)reader["category"];
                    en.CreationDate = (DateTime)reader["creationDate"];
                    return true;
                }

                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("La operación de producto ha fallado. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }
        public bool ReadFirst(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Products ORDER BY code ASC", c);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    en.Code = reader["code"].ToString();
                    en.Name = reader["name"].ToString();
                    en.Amount = (int)reader["amount"];
                    en.Price = float.Parse(reader["price"].ToString());
                    en.Category = (int)reader["category"];
                    en.CreationDate = (DateTime)reader["creationDate"];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("La operación de producto ha fallado. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool ReadNext(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Products ORDER BY code ASC", c);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["code"].ToString() == en.Code && reader.Read())
                    {
                        en.Code = reader["code"].ToString();
                        en.Name = reader["name"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = float.Parse(reader["price"].ToString());
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                }

                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("La operación de producto ha fallado. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }
        public bool ReadPrev(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Products ORDER BY code DESC", c);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["code"].ToString() == en.Code && reader.Read())
                    {
                        en.Code = reader["code"].ToString();
                        en.Name = reader["name"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = float.Parse(reader["price"].ToString());
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                }

                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("La operación de producto ha fallado. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }

        }

    }
}
