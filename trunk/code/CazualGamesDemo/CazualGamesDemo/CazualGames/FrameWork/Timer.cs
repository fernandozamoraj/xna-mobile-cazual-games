using System;
using CazualGames.Sprites;

namespace CazualGames.FrameWork
{
    public class Timer
    {
        private IDateTimeNow _dateTimeNow;
        private int _intervalInMilliseconds;
        private DateTime _lastStarted;

        public Timer(IDateTimeNow dateTimeNow)
        {
            _dateTimeNow = dateTimeNow;
        }

        public void Start(int intervalInMilliseconds)
        {
            _intervalInMilliseconds = intervalInMilliseconds;
            _lastStarted = _dateTimeNow.Now();
        }

        public void ReStart()
        {
            _lastStarted = _dateTimeNow.Now();
        }

        public bool HasTheTimePassed()
        {
            if(_dateTimeNow.Now().Subtract(_lastStarted).TotalMilliseconds >= _intervalInMilliseconds)
            {
                return true;
            }

            return false;
        }
    }
}