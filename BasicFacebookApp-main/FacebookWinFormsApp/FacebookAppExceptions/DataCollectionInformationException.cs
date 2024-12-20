using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System;

public class DataCollectionInformationException : Exception
{
    public DataCollectionInformationException(string message)
        : base(message) { }
    public override string ToString()
    {
        return $"DataCollectionInformationExcption: {Message}, StackTrace: {StackTrace}";
    }
}