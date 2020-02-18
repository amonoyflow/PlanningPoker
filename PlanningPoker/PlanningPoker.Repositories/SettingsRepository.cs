using PlanningPoker.Repositories.DataObjects;
using PlanningPoker.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace PlanningPoker.Repositories
{
    public class SettingsRepository : RepositoryBase, ISettingsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsRepository"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public SettingsRepository(IDatabase database) : base(database) { }

        /// <summary>
        /// Saves the settings to database.
        /// </summary>
        /// <param name="settings"></param>
        public async Task<int> SaveSettings(SettingsDto settings)
        {
            await this.DB.DeleteAllAsync<SettingsDto>();

            return await this.DB.SaveItemAsync(settings);
        }

        /// <summary>
        /// Gets the settings from database.
        /// </summary>
        /// <returns></returns>
        public async Task<SettingsDto> GetSettings()
        {
            var items = await this.DB.GetItemListAsync<SettingsDto>();

            return items.FirstOrDefault();
        }
    }
}
