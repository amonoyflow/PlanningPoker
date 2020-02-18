using System;
using System.IO;
using PlanningPoker.Repositories.Interfaces;
using SQLite;

namespace PlanningPoker.iOS.Database
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

            var libraryPath = Path.Combine(personalFolder, "..", "Library", databaseName);

            return new SQLiteAsyncConnection(libraryPath, true);
        }
    }
}