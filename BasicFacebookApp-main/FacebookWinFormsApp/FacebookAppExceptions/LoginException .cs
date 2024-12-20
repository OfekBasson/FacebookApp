using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System;

public class LoginException : Exception
{
    public LoginException(string message)
        : base(message) { }
    public override string ToString()
    {
        return $"LoginException: {Message}, StackTrace: {StackTrace}";
    }
}