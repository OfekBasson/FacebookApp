internal class DataCollectionInformationException : Exception
{
    public DataCollectionInformationException(string message)
        : base(message) { }
    public override string ToString()
    {
        return $"DataCollectionInformationExcption: {Message}, StackTrace: {StackTrace}";
    }
}