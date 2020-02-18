using PlanningPoker.Common.Enums;
using PlanningPoker.Managers.Entities;
using System.Threading.Tasks;

namespace PlanningPoker.Managers.Interfaces
{
    public interface ISettingsManager
    {
        /// <summary>
        /// Saves the current settings.
        /// </summary>
        /// <param name="theme">The theme to save.</param>
        void SaveSettings(Themes theme);

        /// <summary>
        /// Gets the current theme.
        /// </summary>
        /// <returns>The theme currently saved.</returns>
        Task<SettingsEntity> GetTheme();
    }
}
