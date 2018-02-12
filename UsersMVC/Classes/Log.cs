using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace UsersMVC
{
    public class Log
    {
        private string stringConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsersMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void WriteException(Exception ex, string detail)
        {
            string sqlReaqest = "Insert into Log(Exception, Details) values(N'"+ ex.ToString()+"',N'"+ detail +"')";

            using (var Connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(sqlReaqest, Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }
        public void WriteEvent(string Event, string detail)
        {
            string sqlReaqest = "Insert into Log(Event, Details) values(N'" + Event + "',N'" + detail + "')";

            using (var Connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(sqlReaqest, Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}