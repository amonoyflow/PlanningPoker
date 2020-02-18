using SQLite;

namespace PlanningPoker.Repositories.Interfaces
{
    public interface IDatabaseFactory
    {
        /// <summary>
        /// Creates a sqlite connection.
        /// </summary>
        /// <returns>The connection to sqlite.</returns>
        SQLiteAsyncConnection CreateConnection(string databaseName);
    }
}
