using System;

namespace CazualGames.MarketPlace.Licensing
{
    public interface ILicensingService
    {
        bool IsInTrialMode(Func<bool> additionalCriteriaFuction);
    }
}
