﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Configuration;

namespace CodingTracker
{
    class Program
    {        
        static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        static void Main(string[] args)
        {
            DatabaseManager databaseManager = new();
            databaseManager.CreateTable(connectionString);
            GetUserInput getUserInput = new();
            getUserInput.MainMenu();
        }
    }
}
    
