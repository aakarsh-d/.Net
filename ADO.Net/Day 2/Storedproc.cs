//// Stored Procedure with parameters having input and output

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

//         string query = "SELECT Gender, COUNT(*) AS Total FROM dbo.CollegeMaster GROUP BY Gender";
//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            try
//            {
//                connection.Open();  //Open the connection
//                Console.WriteLine("Connection successful!");


//                using (SqlCommand command = new SqlCommand(query, connection))
//                {

//                    //command.Parameters.Add("@Deg", SqlDbType.VarChar, 50).Value = "BTech";
//                    using (SqlDataReader reader = command.ExecuteReader())  //execute reader to read data from the database
//                    {
//                    Console.WriteLine("\nGender Wise total count");

//                        while (reader.Read())
//                        {
//                            string gender =reader.GetString(0);
//                            int total = reader.GetInt32(1);

//                            Console.WriteLine($"{gender}:{total}");
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



using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs =
            "Data Source=aakarsh\\SQLEXPRESS;" +
            "Initial Catalog=AchaValaDb;" +
            "Integrated Security=True;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";

        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();

            using (SqlCommand cmd = new SqlCommand("usp_getStudentsCount", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // input parameter
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = "Male";

                // output parameter
                SqlParameter outParam =
                    new SqlParameter("@Total", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                int total = (int)cmd.Parameters["@Total"].Value;

                Console.WriteLine("Total Male students = " + total);
                Console.ReadLine();
            }
        }
    }
}











