using PS.Infrastructure.Localization;
using PS.Model;

namespace PS.Service
{
    public class LocalizationService : ILocalizationService
    {
        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <returns>A string representing the requested resource string.</returns>
        public virtual string GetResource(string resourceKey)
        {
            return Resources.ResourceManager.GetString(resourceKey, Resources.Culture) ?? "";            
        }
    }
}
