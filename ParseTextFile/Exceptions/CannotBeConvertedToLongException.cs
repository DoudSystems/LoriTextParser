namespace ParseTextFile;

public class CannotBeConvertedToLongException : Exception
{
    public CannotBeConvertedToLongException()
        : base() {}
    public CannotBeConvertedToLongException(string Message)
        : base(Message) {}
    public CannotBeConvertedToLongException(string Message, Exception InnerException)
        : base(Message, InnerException) {}
}
