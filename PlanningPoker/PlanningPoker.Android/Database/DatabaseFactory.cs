using PlanningPoker.Repositories.Interfaces;
using SQLite;
using System;
using System.IO;

namespace PlanningPoker.Droid.Database
{
    public class DatabaseFactory : IDatabaseFactory
    {
        /// <summary>
        /// Creates a sqlite connection.
        /// </summary>
        /// <returns>The connection to sqlite.</returns>
        public SQLiteAsyncConnection CreateConnection(string databaseName)
        {
            var personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var databasePath = Path.Combine(personalFolder, databaseName);

            return new SQLiteAsyncConnection(databasePath);
        }
    }
}