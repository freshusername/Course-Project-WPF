﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace DemoMain
{
    public class InitializeDBUsers
    {
        private const string DbName = "UsersDB";
        private const string ServerName = @"EXPLORER\SQL2017";
        private const string Authentication = "Integrated Security=true";
        public string OKstr { get; set; }
        public void Initialize()
        {
            CreateDatabase(DbName, ServerName, Authentication);

            string connectionString = $@"
                Server={ServerName}; 
                Database={DbName}; 
                {Authentication};";

            //create Db using sql query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = File.ReadAllText(@"D:\course 2\1.C#\ProjectWPF\Course-Project-WPF\DemoMain\DemoMain\Database\TablesDataUsers.sql");
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.ExecuteNonQuery();
                }
                OKstr = "Database UsersDB has being created!";
            }
        }

        private static void CreateDatabase(string dbName, string serverName, string authentication)
        {
            string connectionString = $@"
                Server={serverName}; 
                Database=master; 
                {authentication};";

            //create Db using sql query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"CREATE DATABASE {dbName};", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
