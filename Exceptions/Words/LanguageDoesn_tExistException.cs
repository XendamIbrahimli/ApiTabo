namespace Tabo.Exceptions.Words
{
    public class LanguageDoesn_tExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status406NotAcceptable;
        public string ErrorMessage { get; }

        public LanguageDoesn_tExistException()
        {
            ErrorMessage = "This LangCode doesn't exist";
        }
        public LanguageDoesn_tExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
