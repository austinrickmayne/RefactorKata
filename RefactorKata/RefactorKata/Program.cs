using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program 
    {
        static void Main(string[] arg)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Products";
  
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                var prod = new Product
                {
                    name = reader["Name"].ToString()
                };
                products.Add(prod);
            }
            conn.Dispose();
            Console.WriteLine("Products Loaded!");
            for(int i =0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].name);
            }
        }
    }
    public class Product
    {
        public string name;
        public string Name { get; set; }     
    }
}
