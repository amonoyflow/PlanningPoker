using PlanningPoker.Common.Enums;
using System;

namespace PlanningPoker.Styles
{
    public class Styles
    {
        public static Themes Theme { get; set; }

        public static event EventHandler ThemeChanged;

        public static void Init(Themes theme)
        {
            Theme = theme;
            App.Current.Resources.MergedDictionaries.Clear();

            App.Current.Resources.MergedDictionaries.Add(new ColorsTheme());
            App.Current.Resources.MergedDictionaries.Add(new Converters());

            switch (theme)
            {
                case Themes.Dark:
                    App.Current.Resources.MergedDictionaries.Add(new DarkTheme());
                    break;
                case Themes.Light:
                    App.Current.Resources.MergedDictionaries.Add(new LightTheme());
                    break;
            }

            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}
