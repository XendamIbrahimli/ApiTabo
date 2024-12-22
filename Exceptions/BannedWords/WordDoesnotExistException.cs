namespace Tabo.Exceptions.BannedWords
{
    public class WordDoesnotExistException:Exception,IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }

        public WordDoesnotExistException()
        {
            ErrorMessage = "This Word doesn't exist";
        }
        public WordDoesnotExistException(string message):base(message)
        {
            ErrorMessage = message;
        }
    }
}
