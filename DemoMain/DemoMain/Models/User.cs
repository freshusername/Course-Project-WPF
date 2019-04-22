using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMain.Models
{
    class User
    {
        private static User instance;

        // model fields
        public string Login { get; }

        public string Email { get; }

        public string Password { get; }

        public bool IsRealtor { get; }

        // GetInstance method
        public static User GetInstance(string login, string email, string password, bool isRealtor)
        {
            if (instance == null)
                instance = new User(login, email, password, isRealtor);

            return instance;
        }

        // Constructor
        private User(string login, string email, string password, bool isRealtor)
        {
            Login = login;

            Email = email;

            Password = password;

            IsRealtor = isRealtor;
        }

        // this method support proper linking with core app form
        public static void Reset()
        {
            instance = null;
        }
    }
}
