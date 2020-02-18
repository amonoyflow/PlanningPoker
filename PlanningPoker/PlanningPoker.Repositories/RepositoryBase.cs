using PlanningPoker.Repositories.Interfaces;
using System;

namespace PlanningPoker.Repositories
{
    public class RepositoryBase
    {
        /// <summary>
        /// Intializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public RepositoryBase(IDatabase database)
        {
            this.DB = database ?? throw new ArgumentNullException(nameof(database));
        }

        public IDatabase DB { get; }
    }
}
