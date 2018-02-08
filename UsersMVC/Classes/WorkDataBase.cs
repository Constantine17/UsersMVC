using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace UsersMVC
{
    /// <summary>
    /// Стек данных пользователя
    /// </summary>
    public struct UserData {
        public string name;
        public string lastName;
        public string email;
        public string phone;
        public int password;
    }

    public class WorkDataBase
    {
        private string stringConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsersMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public WorkDataBase()
        {
            string sqlReaqest = "Select * From Log";

            using (var Connection = new SqlConnection(stringConnection))
            {

                SqlCommand command = new SqlCommand(sqlReaqest, Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    
                    var f= reader["CreatedOn"];
                    i++;
                }
            }

        }

        public bool NonExistEmail(UserData userDate)
        {

            string sqlReaqest = @"Select top 1 id From [User] where Email ='"+userDate.email + "'";

            using (var Connection = new SqlConnection(stringConnection))
            {

                SqlCommand command = new SqlCommand(sqlReaqest, Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                bool exist = reader.HasRows;
                reader.Close();
                if (!exist)
                {
                    string InsterUser = @"Insert into [User](Name, LastName, Email, Phone, Password) values (N'"+ userDate.name + "', N'" + userDate.lastName + "','"+ userDate.email +"','"+ userDate.phone + "', " + userDate.password +")";
                    //new SqlCommand(sqlReaqest, Connection).ExecuteReader().Close();
                    var qq = new SqlCommand(InsterUser, Connection);
                    var dd = qq.ExecuteReader();
                    return true;
                }
            }

            return false;
        }
    }
}