﻿// See https://aka.ms/new-console-template for more information
using System.Configuration;
using System.Globalization;
using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class CodingController
    {
        string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        internal void Post(Coding coding)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using(var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = $"INSERT INTO coding (date, duration) VALUES ('{coding.Date}', '{coding.Duration}')";
                    tableCmd.ExecuteNonQuery();
                }                
            }
        }

        internal void Get()
        {
            List<Coding> tableData = new List<Coding>();
            using(var connection = new SqliteConnection(connectionString))
            {
                using(var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = "SELECT * FROM coding";

                    using (var reader = tableCmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tableData.Add(
                                    new Coding
                                    {
                                        Id = reader.GetInt32(0),
                                        Date = reader.GetString(1),
                                        Duration = reader.GetString(2)
                                    });
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nNo rows found!\n\n");
                        }
                    }
                }
            }
            TableVisualization.ShowTable(tableData);            

            /*  //OLD way from Habit tracker...  I tried it, but not needed!
            Console.WriteLine("--------------------------------------------\n");
            Console.WriteLine("Id#  -  Date  -  Duration\n");
            foreach (var dw in tableData)
            {
                Console.WriteLine($"{dw.Id} - {dw.Date} - {dw.Duration} time");
            }
            Console.WriteLine("--------------------------------------------\n");
            */
        }
    }
}