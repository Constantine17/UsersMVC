using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Threading;

namespace UsersMVC
{
    /// <summary>
    /// Стек данных пользователя
    /// </summary>
    public struct UserData {
        public Guid id;
        public string name;
        public string lastName;
        public string email;
        public string phone;
        public int password;
    }

    /// <summary>
    /// Класс работы с таблицей User
    /// </summary>
    public class WorkDataBase
    {
        private string stringConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsersMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Добавление дового пользователя с систему, метод возвращает индификатор пользователя
        /// </summary>
        /// <param name="userDate"></param>
        /// <returns></returns>
        public Guid NonExistEmail(UserData userDate)
        {
            Guid userId = Guid.Empty;
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
                    userId = Guid.NewGuid();
                    string InsterUser = @"Insert into [User](Id ,Name, LastName, Email, Phone, Password) values ('"+ userId +"',N'"+ userDate.name + "', N'" + userDate.lastName + "','"+ userDate.email +"','"+ userDate.phone + "', " + userDate.password +")";
                    new SqlCommand(InsterUser, Connection).ExecuteReader().Close();

                    new Log().WriteEvent("Created new user", "id="+ userId + " email="+ userDate.email);
                }
            }

            return userId;
        }

        /// <summary>
        /// Получение данных пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserData GetUserData(Guid id)
        {
            UserData userData = new UserData();
            string sqlReaqest = "Select top 1 * From [User] where Id ='"+ id +"'";

            using (var Connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(sqlReaqest, Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                userData.name = (string)reader["Name"];
                userData.lastName = (string)reader["LastName"];
                userData.email = (string)reader["Email"];
                userData.phone = (string)reader["Phone"];

            }
            return userData;
        }

        /// <summary>
        /// Авторизация пользователя, возвращет индефикатор существуещего пользователя, иначе Guid.Empty 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Guid SearchUser(string email, int password)
        {
            Guid userId = Guid.Empty;

            string sqlReaqest = @"Select top 1 id From [User] where Email ='" + email + "' and Password =" + password;

            using (var Connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(sqlReaqest, Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    userId = (Guid)reader["Id"];
                    new Log().WriteEvent("User is login", "id=" + userId);
                }
            }
            return userId;
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <param name="userDate"></param>
        /// <returns></returns>
        public bool UpdateUserData(UserData userDate)
        {
            string sqlReaqest = @"Update top(1) [User] set Name=N'"+userDate.name+"', LastName=N'"+userDate.lastName + "', Phone = '"+ userDate.phone +"' where Id='"+ userDate.id +"'";

            using (var Connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(sqlReaqest, Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                new Log().WriteEvent("User changed data", "id=" + userDate.id + " email=" + userDate.email);
            }          
            return true;
        }
    }
}