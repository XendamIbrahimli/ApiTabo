namespace Tabo.Exceptions.Games
{
    public class GameAlreadyStartedException:Exception, IBaseException
    {
        public GameAlreadyStartedException()
        {
            ErrorMessage = "Game Already was started.";
        }

        public int StatusCode=>StatusCodes.Status400BadRequest;
        public string ErrorMessage { get; }

    }
}
