using System;

namespace CazualGames.Core
{
    public class CazualGamesException : Exception
    {
        public CazualGamesException(string message, Exception innerException) : base(message + " " + innerException.Message, innerException)
        {
             
        }

        public CazualGamesException(string message) : base(message)
        {
        }
    }
}