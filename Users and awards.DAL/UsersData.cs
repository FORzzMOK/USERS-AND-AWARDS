using System;
using System.Collections.Generic;
using System.Text;
using UsersEntities;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Users_and_awards.DAL
{
    public class UsersData : IUsersStorage
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static void checkAwards(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users_Awards WHERE Users_ID = 1", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));// выводим названия столбцов
                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object usersId = reader.GetValue(1);
                        object award = reader.GetValue(2);
                        Console.WriteLine("{0} \t{1} \t{2}", id, usersId, award);
                    }
                }
                reader.Close();
            }
        }
        private static List<User> UsersList = new List<User>();//Мой юзер лист внутри программы

        public void AddUser(User newUser)
        {
            UsersList.Add(newUser);
            File.AppendAllText(@"C:\Users\pavel\source\repos\6.1.USERS AND AWARDS\DataBase\MyData.txt", $"{newUser.ToString()} \n");
        }//Добавляет Юзера в базу данных

        public bool RemoveUser(int usersId)//Удаление юзера
        {
            User myUser = GetUserById(usersId);
            if (myUser != null)
            {
                UsersList.Remove(myUser);
                return true;
            }
            else return false;

        }//Удаляет Юзера из базы данных
        public int GetId()//Получить новое ID для юзера
        {
            int newId = -1;
            foreach (User item in UsersList)
            {
                if (item.Id > newId) newId = item.Id;
            }
            return newId + 1;
        }
        public User GetUserById(int usersId)//Получить экземпляр юзера по ID
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                User myUser = new User();
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM Users_first WHERE ID = {usersId}", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        myUser = new User
                        {
                            Id = int.Parse($"{reader.GetValue(0)}"),
                            Name = $"{reader.GetValue(1)} {reader.GetValue(2)}",
                            DateOfBirth = DateTime.Parse($"{reader.GetValue(3)}")
                        };
                    reader.Close();
                    return myUser;
                }
                return null;
            }
        }

        public string GetUsersList()//Получить список юзеров\ ПЕРЕПИСАНО
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                StringBuilder UsersListString = new StringBuilder();
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users_first", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    UsersListString.Append($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)} \t{reader.GetName(3)}\n");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object secondName = reader.GetValue(2);
                        DateTime dateOfBird = DateTime.Parse($"{reader.GetValue(3)}");
                        UsersListString.Append($"{id}\t{name}\t{secondName} \t{dateOfBird.ToString("yyyy.MM.dd")}\t\n");
                    }
                }
                reader.Close();
                return UsersListString.ToString();
            }  
        }
    }
}
