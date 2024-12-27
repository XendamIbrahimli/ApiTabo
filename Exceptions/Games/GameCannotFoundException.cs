namespace Tabo.Exceptions.Games
{
    public class GameCannotFoundException : Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }

        public GameCannotFoundException() 
        {
            ErrorMessage ="Game cann't found";
        }

        public GameCannotFoundException(string errorMessage):base(errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
