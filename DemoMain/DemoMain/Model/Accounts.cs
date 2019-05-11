//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoMain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Accounts
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }


        public static List<Accounts> GetAccounts()
        {
            CarsDBEntities context = new CarsDBEntities();
            var res = new List<Accounts>();

            var test = context.Accounts
                .Select(e => new
                {
                    login = e.Login,
                    password = e.Password,
                    email = e.Email,
                    isadmin = e.IsAdmin
                });


            foreach (var item in test)
            {
                res.Add(new Accounts { Login = item.login, Password = item.password, Email = item.email, IsAdmin = item.isadmin });
            }
            return res;
        }
    }
}