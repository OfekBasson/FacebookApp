internal class LoginException : Exception
{
    public LoginException(string i_Message)
        : base(i_Message) { }
    public override string ToString()
    {
        return $"LoginException: {Message}, StackTrace: {StackTrace}";
    }
}