// See https://aka.ms/new-console-template for more information
using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class DatabaseManager
    {
        internal void CreateTable(string connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS coding (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Duration TEXT
                    )";

                    tableCmd.ExecuteNonQuery();                 
                }                    
            }
        }
    }
}