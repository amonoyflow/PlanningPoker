using System;
using System.Threading.Tasks;
using PlanningPoker.Common.Enums;
using PlanningPoker.Managers.Entities;
using PlanningPoker.Managers.Interfaces;
using PlanningPoker.Repositories.DataObjects;
using PlanningPoker.Repositories.Interfaces;

namespace PlanningPoker.Managers
{
    public class SettingsManager : ManagerBase, ISettingsManager
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsManager(ISettingsRepository settingsRepository) : base()
        {
            this._settingsRepository = settingsRepository ?? throw new ArgumentNullException(nameof(settingsRepository));
        }

        /// <summary>
        /// Saves the current settings.
        /// </summary>
        /// <param name="theme">The theme to save.</param>
        public void SaveSettings(Themes theme)
        {
            this._settingsRepository.SaveSettings(new SettingsDto() { Theme = theme.ToString() });
        }

        /// <summary>
        /// Gets the current theme.
        /// </summary>
        /// <returns>The theme currently saved.</returns>
        public async Task<SettingsEntity> GetTheme()
        {
            var settings = await this._settingsRepository.GetSettings();

            if (settings != null)
            {
                return new SettingsEntity() { Theme = settings.Theme };
            }

            return null;
        }
    }
}
