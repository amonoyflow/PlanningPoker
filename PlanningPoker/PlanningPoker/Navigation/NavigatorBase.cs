using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlanningPoker.Navigation
{
    public class NavigatorBase : NavigationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationBase"/> class.
        /// </summary>
        /// <param name="rootPage">The root page.</param>
        public NavigatorBase(Page rootPage) : base(rootPage)
        {
        }

        /// <summary>
        /// A task for asynchronously pushing a page onto the navigation stack, with optional animation.
        /// </summary>
        /// <param name="page">The page to push to navigation stack.</param>
        /// <param name="animated"><c>True</c> if the transition will be animated else <c>False</c>.</param>
        public new async Task PushAsync(Page page, bool animated)
        {
            await base.PushAsync(page, animated);
        }

        /// <summary>
        /// Asynchronously removes the top <see cref="T:Xamarin.Forms.Page" /> from the navigation stack, with optional animation.
        /// </summary>
        /// <param name="animated"><c>True</c> if the transition will be animated else <c>False</c>.</param>
        public new async Task<Page> PopAsync(bool animated)
        {
            return await base.PopAsync(animated);
        }
    }
}
