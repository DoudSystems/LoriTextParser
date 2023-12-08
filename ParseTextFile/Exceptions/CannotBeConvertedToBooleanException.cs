namespace ParseTextFile;

public class CannotBeConvertedToBooleanException : Exception
{
    public CannotBeConvertedToBooleanException()
        : base() {}
    public CannotBeConvertedToBooleanException(string Message)
        : base(Message) {}
    public CannotBeConvertedToBooleanException(string Message, Exception InnerException)
        : base(Message, InnerException) {}}
