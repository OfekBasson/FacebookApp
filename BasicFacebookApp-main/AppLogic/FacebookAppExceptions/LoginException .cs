internal class LoginException : Exception
{
    public LoginException(string message)
        : base(message) { }
    public override string ToString()
    {
        return $"LoginException: {Message}, StackTrace: {StackTrace}";
    }
}