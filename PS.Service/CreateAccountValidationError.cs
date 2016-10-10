namespace PS.Service
{
    public enum CreateAccountValidationError
    {
        EmailNotUnique,
        UsernameNotUnique,
        UsernameNotValid,
        UsernameProfane,
        EmailNotValid,
        PasswordNotValid,
    }
}