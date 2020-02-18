using System;
using PlanningPoker.Common.Constants;
using PlanningPoker.Navigation;
using Xamarin.Forms;

namespace PlanningPoker
{
    public partial class App : Application
    {
        private readonly INavigator _navigator;

        public App(INavigator navigator)
        {
            this._navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));

            this.InitializeComponent();

            //this.InitializeMainPage();

            this.InitializeTestPage();
        }

        private void InitializeMainPage()
        {
            this._navigator.InitializeRootView(ViewNames.HomeView);
            this.MainPage = this._navigator.NavigationBase;
        }

        private void InitializeTestPage()
        {
            this.MainPage = new Views.TestView();
        }
    }
}
