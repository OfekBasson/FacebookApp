internal class DataCollectionInformationException : Exception
{
    public DataCollectionInformationException(string i_Message)
        : base(i_Message) { }
    public override string ToString()
    {
        return $"DataCollectionInformationExcption: {Message}, StackTrace: {StackTrace}";
    }
}