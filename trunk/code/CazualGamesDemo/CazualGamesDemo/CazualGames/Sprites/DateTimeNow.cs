using System;

namespace CazualGames.Sprites
{
    public class DateTimeNow : IDateTimeNow
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

    }
}