using PlanningPoker.Repositories.DataObjects;
using System.Threading.Tasks;

namespace PlanningPoker.Repositories.Interfaces
{
    public interface ISettingsRepository
    {
        /// <summary>
        /// Saves the settings to database.
        /// </summary>
        /// <param name="settings"></param>
        Task<int> SaveSettings(SettingsDto settings);

        /// <summary>
        /// Gets the settings from database.
        /// </summary>
        /// <returns></returns>
        Task<SettingsDto> GetSettings();
    }
}
