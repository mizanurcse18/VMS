namespace PS.Model.Enums
{
    /// <summary>
    /// This enum is duplicated in the LoginType table
    /// </summary>
    public enum UserAuthenticationType
    {
        UsernamePassword = 0,
        ExternalTwitter = 1,
        ExternalFacebook = 2,
        EmailOnly = 3
    }
}