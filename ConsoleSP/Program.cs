using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string nameSP = "ALL_STUDENTS";
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Dados;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (var conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("[dbo]." + nameSP, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                var returnValue = cmd.ExecuteReader();
                string variavel = "";
                while (returnValue.Read())
                {
                    variavel = returnValue["Name"].ToString();
                    Console.WriteLine(variavel);
                }
            }
        }
    }
}
