namespace ParseTextFile;

public class CannotBeConvertedToDecimalException : Exception
{
    public CannotBeConvertedToDecimalException()
        : base() {}
    public CannotBeConvertedToDecimalException(string Message)
        : base(Message) {}
    public CannotBeConvertedToDecimalException(string Message, Exception InnerException)
        : base(Message, InnerException) {}}
