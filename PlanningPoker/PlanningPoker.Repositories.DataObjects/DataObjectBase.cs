using PlanningPoker.Repositories.DataObjects.Interfaces;
using SQLite;

namespace PlanningPoker.Repositories.DataObjects
{
    public class DataObjectBase : IDataObjectBase
    {
        /// <summary>
        /// Gets or sets the identifier of the data on database.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public virtual int ID { get; set; }
    }
}
