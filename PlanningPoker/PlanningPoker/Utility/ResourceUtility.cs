using System.Linq;
using Xamarin.Forms;

namespace PlanningPoker.Utility
{
    public static class ResourceUtility
    {
        /// <summary>
        /// Method for getting Application set resources Eg. Colors, Styles, Etc.
        /// </summary>
        /// <param name="fieldName">key of the resource</param>
        /// <returns>object that is mutable to the type of resource.</returns>
        public static object GetResource(string fieldName)
        {
            if (Application.Current?.Resources?.MergedDictionaries != null && Application.Current.Resources.MergedDictionaries.Any())
            {
                foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
                {
                    if (dictionary.ContainsKey(fieldName))
                    {
                        return dictionary[fieldName];
                    }
                }
            }

            return null;
        }
    }
}
