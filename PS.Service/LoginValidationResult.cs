namespace PS.Service
{
    public class LoginValidationResult
    {
        public bool LoginSucceeded { get; set; }
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}