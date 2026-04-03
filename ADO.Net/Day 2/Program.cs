//// Stored Procedure with parameters




//using System;
//using Microsoft.Data.SqlClient;
//using System.Reflection.PortableExecutable;
//using System.Runtime.InteropServices.Marshalling;
//using System.Data;


//class Program
//{
//    static void Main()
//    {
//        string connectionString =
//            "Data Source=aakarsh\\SQLEXPRESS;" +
//            "Initial Catalog=AchaValaDb;" +
//            "Integrated Security=True;" +
//            "Connect Timeout=30;" +
//            "Encrypt=True;" +
//            "TrustServerCertificate=True;";

//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            try
//            {
//                connection.Open();  //Open the connection
//                Console.WriteLine("Connection successful!");

//                //string query = "SELECT Name from CollegeMaster where ID=@id"; //define and execute a sql cmd

//                using (SqlCommand command = new SqlCommand("sp_getStudentDetail", connection))
//                {
//                    command.CommandType = CommandType.StoredProcedure;
//                    //command.Parameters.Add("@id", SqlDbType.Int).Value=1;
//                    command.Parameters.AddWithValue("@id", 1);
//                    command.Parameters.AddWithValue("@Deg", "BTech");

//                    //command.Parameters.Add("@Deg", SqlDbType.VarChar, 50).Value = "BTech";
//                    using (SqlDataReader reader = command.ExecuteReader())  //execute reader to read data from the database
//                    {
//                        Console.WriteLine("\nReading data from stored procedure");
//                        //SqlDataAdapter adapter = new SqlDataAdapter(command);

//                        //SqlCommandBuilder sqlee=new SqlCommandBuilder(adapter);

//                        while (reader.Read())
//                        {
//                            Console.WriteLine($"{reader[0]}{reader[1]} {reader[2]}");
//                        }
//                    }
//                }
//            }
//            catch (SqlException ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }

//        Console.WriteLine("Connection closed.");

//    }

//}