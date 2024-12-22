namespace Tabo.Exceptions.Languages
{
    public class LanguageReferencedException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public LanguageReferencedException()
        {
            ErrorMessage = "You cann't remove this language because it give reference to a word";
        }

        public LanguageReferencedException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
