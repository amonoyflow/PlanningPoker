using System.Threading.Tasks;

namespace PlanningPoker.Navigation
{
    public interface INavigator
    {
        /// <summary>
        /// Gets the navigation base.
        /// </summary>
        NavigatorBase NavigationBase { get; }

        /// <summary>
        /// Push the page to another page based on the name of the view.
        /// </summary>
        /// <param name="viewName">The name of the view.</param>
        /// <param name="parameter">The parameter to pass to next view.</param>
        /// <returns>The task after navigating to another page.</returns>
        Task PushToView(string viewName, object parameter = null);

        /// <summary>
        /// Pops to previous page based on the last page inserted in stack.
        /// </summary>
        /// <param name="parameter">The parameter to pass to previous view.</param>
        /// <returns>The task after navigating back to previous page.</returns>
        Task PopToPreviousView(object parameter = null);

        /// <summary>
        /// Pops to root page.
        /// </summary>
        /// <returns>The task after navigating back to root view.</returns>
        Task PopToRootView();

        /// <summary>
        /// Initializes the root view.
        /// </summary>
        /// <param name="rootViewName">Name of the root view.</param>
        void InitializeRootView(string rootViewName);
    }
}
