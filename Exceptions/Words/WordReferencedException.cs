namespace Tabo.Exceptions.Words
{
    public class WordReferencedException:Exception, IBaseException
    {
        public int StatusCode=>StatusCodes.Status406NotAcceptable;
        public string ErrorMessage { get; }

        public WordReferencedException()
        {
            ErrorMessage = "You cann't remove this word, because it referenced to a BannedWord";
        }

        public WordReferencedException(string message):base(message)
        {
            ErrorMessage = message;
        }
        
    }
}
