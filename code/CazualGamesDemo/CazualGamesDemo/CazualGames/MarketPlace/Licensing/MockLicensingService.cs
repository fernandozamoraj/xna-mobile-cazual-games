using System;

namespace CazualGames.MarketPlace.Licensing
{
    public class MockLicensingService: ILicensingService
    {
        public bool IsInTrialMode(Func<bool> isInTrialMode)
        {
            return isInTrialMode();
        }
    }
}
