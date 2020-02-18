using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Newtonsoft.Json;
using PlanningPoker.Common.Constants;
using PlanningPoker.Common.Enums;
using PlanningPoker.Common.Extensions;
using PlanningPoker.Managers.Interfaces;
using PlanningPoker.Models;
using PlanningPoker.Navigation;
using PlanningPoker.Utility;
using PlanningPoker.ViewModels.Base;
using Xamarin.Forms;

namespace PlanningPoker.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ISettingsManager _settingsManager;

        public HomeViewModel(INavigator navigator, ISettingsManager settingsManager) : base(navigator)
        {
            this._settingsManager = settingsManager ?? throw new ArgumentNullException(nameof(settingsManager));
        }

        public override void InitializeViewModel(object parameter = null)
        {
            this.InitializeStandardCards();
            this.InitializeThemes();
            this.UpdateCards(Menus.Standard);
        }

        private PlanningPokerCards _planningPokerCards;
        public PlanningPokerCards PlanningPokerCards
        {
            get { return this._planningPokerCards; }
            set { this.Set(ref this._planningPokerCards, value); }
        }

        private IEnumerable<string> _cards;
        public IEnumerable<string> Cards
        {
            get { return this._cards; }
            set { this.Set(ref this._cards, value); }
        }

        private string _selectedCard;
        public string SelectedCard
        {
            get { return this._selectedCard; }
            set { this.Set(ref this._selectedCard, value); }
        }

        private bool _isTapToReveal;
        public bool IsTapToReveal
        {
            get { return this._isTapToReveal; }
            set { this.Set(ref this._isTapToReveal, value); }
        }

        private Style _selectedCardLabelStyle = (Style)ResourceUtility.GetResource("SelectedCardLabelStyle");
        public Style SelectedCardLabelStyle
        {
            get { return this._selectedCardLabelStyle; }
            set { this.Set(ref this._selectedCardLabelStyle, value); }
        }

        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get { return this._isDarkMode; }
            set { this.Set(ref this._isDarkMode, value); }
        }

        public ICommand TapToRevealCommand
        {
            get { return new Command(() => this.IsTapToReveal = false); }
        }

        public void UpdateCards(Menus menu)
        {
            switch (menu)
            {
                case Menus.Standard:
                    this.Cards = this.PlanningPokerCards.Standard;
                    break;
                case Menus.TShirt:
                    this.Cards = this.PlanningPokerCards.TShirt;
                    break;
                case Menus.Fibonacci:
                    this.Cards = this.PlanningPokerCards.Fibonacci;
                    break;
                case Menus.Settings:
                    break;
            }

            this.SelectedCard = this.Cards.FirstOrDefault();
        }

        private void InitializeStandardCards()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ViewNames)).Assembly;

            using (var stream = assembly.GetManifestResourceStream("PlanningPoker.Common.Files.cards.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    this.PlanningPokerCards = JsonConvert.DeserializeObject<PlanningPokerCards>(reader.ReadToEnd());
                }
            }
        }

        private async void InitializeThemes()
        {
            var settings = await this._settingsManager.GetTheme();

            if (settings != null)
            {
                this.IsDarkMode = settings.Theme.ToEnum<Themes>() == Themes.Dark;
            }
        }

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(this.SelectedCard))
            {
                this.SelectedCardLabelStyle = this.SelectedCard.Length > 2 ? (Style)ResourceUtility.GetResource("SelectedCardLabelStyle2") : (Style)ResourceUtility.GetResource("SelectedCardLabelStyle");
            }
        }
    }
}
