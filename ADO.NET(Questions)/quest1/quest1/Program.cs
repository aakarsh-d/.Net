using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    //static string conStr = "";'

    static string connectionString ="Data Source=aakarsh\\SQLEXPRESS;" +
            "Initial Catalog=AchaValaDb;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";
    static void GetEmployeesByDepartment(string dept)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Department", dept);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nEmployees in Department: " + dept);
            while (reader.Read())
            {
                Console.WriteLine($"{reader["EmpId"]} | {reader["Name"]} | {reader["Phone"]} | {reader["Email"]}");
            }
        }
    }
}