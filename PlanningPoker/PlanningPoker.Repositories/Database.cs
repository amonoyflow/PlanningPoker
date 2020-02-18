using PlanningPoker.Repositories.DataObjects;
using PlanningPoker.Repositories.DataObjects.Interfaces;
using PlanningPoker.Repositories.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningPoker.Repositories
{
    public class Database : IDatabase
    {
        private const string DatabaseName = "PlanningPoker.db";

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public Database(IDatabaseFactory databaseFactory)
        {
            this.DB = databaseFactory.CreateConnection(DatabaseName);

            this.DB.CreateTableAsync<SettingsDto>().Wait();
        }

        private SQLiteAsyncConnection DB { get; }

        /// <summary>
        /// Save the item to local database.
        /// </summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="item">The item to save.</param>
        /// <returns>The Identifier of saved item.</returns>
        public async Task<int> SaveItemAsync<T>(T item) where T : class, IDataObjectBase, new()
        {
            if (item.ID != 0)
            {
                return await this.DB.UpdateAsync(item);
            }
            else
            {
                return await this.DB.InsertAsync(item);
            }
        }

        /// <summary>
        /// Gets the item from local database.
        /// </summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="id">The identifier of item.</param>
        /// <returns>The saved item.</returns>
        public async Task<T> GetItemAsync<T>(int id) where T : class, IDataObjectBase, new()
        {
            return await this.DB.Table<T>().FirstOrDefaultAsync(_ => _.ID == id);
        }

        /// <summary>
        /// Gets the list of item from local database.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <returns>The list of item.</returns>
        public async Task<IEnumerable<T>> GetItemListAsync<T>() where T : class, IDataObjectBase, new()
        {
            return await this.DB.Table<T>().ToListAsync();
        }

        /// <summary>
        /// Deletes all data on database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<int> DeleteAllAsync<T>() where T : IDataObjectBase, new()
        {
            return await this.DB.DeleteAllAsync<T>();
        }
    }
}
