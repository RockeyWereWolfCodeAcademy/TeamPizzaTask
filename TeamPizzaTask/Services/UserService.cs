using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPizzaTask.Databases;
using TeamPizzaTask.Exceptions;
using TeamPizzaTask.Models;

namespace TeamPizzaTask.Services
{
    internal static class UserService
    {
        public static void AddUser(string name, string surname, string login, string password, bool isAdmin)
        {
            UsersDatabase.Users.Add(new User { Name = name, Surname = surname, Login = login, Password = password, IsAdmin = isAdmin});
        }

        public static List<User> GetUsers()
        {
            return UsersDatabase.Users;
        }

        public static User GetUserById(uint id)
        {
            var user = UsersDatabase.Users.Find(b => b.Id == id);
            if (user == null)
                throw new UserNotFoundException("There is no product with this ID");
            else
                return user;
        }
        public static void UpdateUser(uint id)
        {
            var user = GetUserById(id);
            Console.WriteLine($"User {user.Login} admin status: {user.IsAdmin}");
            Console.WriteLine("Choose from options:");
            Console.WriteLine("1. Give admin rights");
            Console.WriteLine("2. Take admin rights");
            char choice = Console.ReadKey(intercept: true).KeyChar;

            switch (choice)
            {
                case '1':
                    user.IsAdmin = true;
                    break;
                case '2':
                    user.IsAdmin = false;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }

        public static void RemoveUser(uint id)
        {
            UsersDatabase.Users.Remove(GetUserById(id));
        }
    }
}
