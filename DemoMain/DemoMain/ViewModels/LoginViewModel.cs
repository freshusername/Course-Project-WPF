using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using DemoMain.Models;
namespace DemoMain.ViewModels
{
    class LoginViewModel
    {
        // connection string
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\course 2\1.C#\ProjectWPF\Course-Project-WPF\DemoMain\DemoMain\CarsDB.mdf;Integrated Security=True";

        // insert user to Accounts table after clicking on registration button
        public void InsertUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("select * from Accounts", connection);

                DataSet set = new DataSet();

                adapter.Fill(set);

                var table = set.Tables[0];

                DataRow row = table.NewRow();

                row[0] = user.Login;
                row[1] = user.Email;
                row[2] = user.Password;
                row[3] = user.IsAdmin;

                table.Rows.Add(row);

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.Update(set);
            }
        }

        // checking authorization by clicking on log_in button
        public bool PassAuthorization(string check_login, string check_pass)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("select Login, Password from Accounts", connection);

                DataSet set = new DataSet();

                adapter.Fill(set);

                Dictionary<string, string> accs = new Dictionary<string, string>();

                foreach (DataRow acc in set.Tables[0].Rows)
                {
                    accs.Add(acc.Field<string>("Login").Trim(), acc.Field<string>("Password").Trim());
                }

                if (accs.TryGetValue(check_login, out string t))
                {
                    if (t == check_pass)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        // sending email with login & password
        public void SendRecovery(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter($"select login, password from Accounts where email = '{email}'", connection);

                DataSet dbset = new DataSet();

                adapter.Fill(dbset);

                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();

                foreach (DataRow row in dbset.Tables[0].Rows)
                {
                    pairs.Add(new KeyValuePair<string, string>(row.Field<string>("login"), row.Field<string>("password")));
                }

                if (pairs.Count > 0)
                {
                    string message = "";

                    foreach (var pair in pairs)
                    {
                        message += $"<strong>Login : {pair.Key}<br>Password : {pair.Value}</strong><br><br>";
                    }

                    SendEmailAsync(email, message).GetAwaiter();
                }
            }
        }

        // async task responsible for sending email
        public static async Task SendEmailAsync(string toMailAdress, string body)
        {
            MailAddress from = new MailAddress("TestOOP@gmail.com", "TestOOP");

            MailAddress to = new MailAddress(toMailAdress);

            MailMessage message = new MailMessage(from, to)
            {
                Subject = "Возобновление логина и пароля",
                Body = body,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("TestOOP@gmail.com", "TestOOP"),
                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }

        // this method is responsible for preparing appropriate User object for beeing used in LoadFromAcc method
        public User LoadUser(string login)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter($"select * from Accounts where Login='{login}'", con);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    return User.GetInstance(row.Field<string>("Login"), row.Field<string>("Email"), row.Field<string>("Password"), row.Field<bool>("IsAdmin"));
                }
                else
                    return null;
            }
        }





        
    }
}
