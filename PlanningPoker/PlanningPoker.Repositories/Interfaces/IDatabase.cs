using PlanningPoker.Repositories.DataObjects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningPoker.Repositories.Interfaces
{
    public interface IDatabase
    {
        /// <summary>
        /// Save the item to local database.
        /// </summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="item">The item to save.</param>
        /// <returns>The Identifier of saved item.</returns>
        Task<int> SaveItemAsync<T>(T item) where T : class, IDataObjectBase, new();

        /// <summary>
        /// Gets the item from local database.
        /// </summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="id">The identifier of item.</param>
        /// <returns>The saved item.</returns>
        Task<T> GetItemAsync<T>(int id) where T : class, IDataObjectBase, new();

        /// <summary>
        /// Gets the list of item from local database.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <returns>The list of item.</returns>
        Task<IEnumerable<T>> GetItemListAsync<T>() where T : class, IDataObjectBase, new();

        /// <summary>
        /// Deletes all data on database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<int> DeleteAllAsync<T>() where T : IDataObjectBase, new();
    }
}
