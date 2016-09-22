using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Labo1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT s.Id as studentId s.FullName as studentName s.Birthday as birthday FROM Student", connection);
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                var studentId = (int)reader("studentId");
                Console.WriteLine(String.Format("{0}, {1}, {2}",
                    reader[0], reader[1], reader[2]));
                Console.WriteLine("Liste des cours:");

            reader.Close();
                connection.Close();
            System.Console.Read();
        }
    }
}
