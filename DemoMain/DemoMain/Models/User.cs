using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMain.Models
{
    //Class User as an implementayion of Singleton pattern
    public class User
    { 
        private static User instance;

        // model fields
        public string Login { get; }

        public string Email { get; }

        public string Password { get; }

        public bool IsAdmin { get; }

        // GetInstance method
        public static User GetInstance(string login, string email, string password, bool IsAdmin)
        {
            if (instance == null)
                instance = new User(login, email, password, IsAdmin);

            return instance;
        }

        // Constructor
        private User(string login, string email, string password, bool IsAdmin)
        {
            Login = login;

            Email = email;

            Password = password;

            this.IsAdmin = IsAdmin;
        }

        // this method support proper linking with core app form
        public static void Reset()
        {
            instance = null;
        }
    }
}
