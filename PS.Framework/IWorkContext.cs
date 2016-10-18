using PS.Framework.Filters;
using PS.Model;
using PS.Model.Models;

namespace PS.Framework
{
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {

        /// <summary>
        /// Gets or sets the current user
        /// </summary>
        HREmployee CurrentUser { get; }

        /// <summary>
        /// Current role, in case user role is impersonated it may be different
        /// </summary>
        Role CurrentRole { get; }
        void SetUser(string userGuid, HREmployee user, Role impersonatedRole);

    }
}
