using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoMain
{
    class CheckUser
    {
        public string OKstr { get; set; }
        string UserNickname ;
        string UserPassword ;
        public CheckUser(string nickname, string password)
        {
            this.UserNickname = nickname;
            this.UserPassword = password;
        }
        
        private const string ConnectionString = @"
            Server=EXPLORER\SQL2017; 
            Database=UsersDB; 
            Integrated Security=true;";
        private const string SelectionQueryPath = @"..\..\CheckUser.sql";

        public void CheckUserFunc()
        {           
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmdText = string.Format(File.ReadAllText(SelectionQueryPath), UserNickname, UserPassword);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@UserNickname", UserNickname);
                    command.Parameters.AddWithValue("@UserPassword", UserPassword);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProcessSelection(reader, UserNickname, UserPassword);
                    }

                }
            }
        }

        private void ProcessSelection(SqlDataReader reader, string UserNickname, string UserPassword)
        {
            if (reader.HasRows)
            {
                 reader.Read();
                
                if (reader.IsDBNull(1))
                {
                    MessageBox.Show("No users!");
                }
                else
                {
                    int usersNumber = 1;
                    while (true)
                    {

                        if (!reader.Read())
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No such users!");
            }
        }
    }
}


