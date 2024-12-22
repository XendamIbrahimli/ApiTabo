namespace Tabo.Exceptions.Languages
{
    public class LanguageExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public LanguageExistException() 
        {
            ErrorMessage="Langauge already was exist.";
        }

        public LanguageExistException(string message):base(message)
        {
            ErrorMessage = message;
        }
    }
}
