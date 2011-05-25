using System;
using System.Collections.Generic;
using CazualGames.FrameWork;
using XnaMobileUnit.FrameWork;

namespace CazualGames.UnitTests.FrameWork
{
    public class TimerTestContext : TestFixture
    {
        protected Timer Timer;
        protected DateTimeNowMockQueue DateTimesQueue;

        public override void Context()
        {
            DateTimesQueue = new DateTimeNowMockQueue();
            this.Timer = new Timer(DateTimesQueue);
        }
    }

    public class WhenTimerIsSetNotEnoughTimeHasPassed : TimerTestContext
    {
        public override void Context()
        {
            base.Context();

            DateTimesQueue.Setup(new DateTime(2000, 1, 1, 12, 0, 0, 0),
                                 new DateTime(2000, 1, 1, 12, 0, 0, 1)
                                        );

            Timer.Start(100);
        }
 
        [TestMethod]
        public void check_that_it_returns_false()
        {
            Assert.AreEqual(false, Timer.HasTheTimePassed(), "Not enough time should have passed");
        }
    }

    public class WhenTimerIsSetAndEnoughTimeHasPassed : TimerTestContext
    {
        public override void Context()
        {
            base.Context();

            Queue<DateTime> dateQueue = new Queue<DateTime>(new[]
                                        {
                                           new DateTime(2000, 1, 1, 12, 0, 0, 0),
                                            new DateTime(2000, 1, 1, 12, 0, 0, 100),
                                        });

            DateTimesQueue.Setup(
                new DateTime(2000, 1, 1, 12, 0, 0, 0),
                new DateTime(2000, 1, 1, 12, 0, 0, 100));

            Timer.Start(100);
        }

        [TestMethod]
        public void should_return_true_because_enough_time_has_passed()
        {
            Assert.AreEqual(true, Timer.HasTheTimePassed(), "Not enough time should have passed");
        }
    }

    public class WhenTimerIsReSetAndNotEnoughTimeHasPassed : TimerTestContext
    {
        public override void Context()
        {
            base.Context();

            this.DateTimesQueue.Setup(new DateTime(2000, 1, 1, 12, 0, 0, 0),
                                            new DateTime(2000, 1, 1, 12, 0, 0, 100), //HasTimePassed
                                            new DateTime(2000, 1, 1, 12, 0, 0, 110), //Restart
                                            new DateTime(2000, 1, 1, 12, 0, 0, 120)); //Final check);

            this.Timer.Start(100);
        }

        [TestMethod]
        public void should_return_false_because_not_enough_time_has_passed()
        {
            Assert.AreEqual(true, Timer.HasTheTimePassed(), "Enough time should have passed");
            Timer.ReStart();

            Assert.AreEqual(false, Timer.HasTheTimePassed(), "Not enough time should have passed");
        }
    }
}
