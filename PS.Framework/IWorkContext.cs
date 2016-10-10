using PS.Framework.Filters;
using PS.Model;

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
        //User CurrentUser { get; }

        /// <summary>
        /// Current role, in case user role is impersonated it may be different
        /// </summary>
        Role CurrentRole { get; }
        //void SetUser(string userGuid, User user, Role impersonatedRole);

    }
}
