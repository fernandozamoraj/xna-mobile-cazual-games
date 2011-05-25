using System;
using System.Collections.Generic;
using CazualGames.Sprites;

namespace CazualGames.UnitTests.FrameWork
{
    public class DateTimeNowMockQueue : IDateTimeNow
    {
        Queue<DateTime> _dateTimeQueue = new Queue<DateTime>();

        public void Setup(params DateTime[] dateTimes)
        {
            foreach (var dateTime in dateTimes)
            {
                _dateTimeQueue.Enqueue(dateTime); 
            }
        }

        public DateTime Now()
        {
            return _dateTimeQueue.Dequeue();
        }
    }
}