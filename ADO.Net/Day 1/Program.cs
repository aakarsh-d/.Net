//Console.WriteLine("Hello, World!");


using conditions to get from DB

using System;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.Marshalling;


class Program
{
    static void Main()
    {
        string connectionString =
            "Data Source=aakarsh\\SQLEXPRESS;" +
            "Initial Catalog=AchaValaDb;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                int id = 5;
                connection.Open();  //Open the connection
                Console.WriteLine("Connection successful!");

                string query = "SELECT Name from CollegeMaster where ID=@id"; //define and execute a sql cmd

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())  //execute reader to read data from the database
                    {
                        Console.WriteLine("\nReading data...");
                        //SqlDataAdapter adapter = new SqlDataAdapter(command);

                        //SqlCommandBuilder sqlee=new SqlCommandBuilder(adapter);

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        Console.WriteLine("Connection closed.");

    }

}



---------------------------------------------------------------------------------
