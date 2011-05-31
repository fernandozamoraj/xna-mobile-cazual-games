using System;
using Microsoft.Phone.Marketplace;

namespace CazualGames.MarketPlace.Licensing
{
    public class LicensingService : ILicensingService
    {
        /// <summary>
        /// Checks to see if the program is in trial mode
        /// </summary>
        /// <param name="additionalCriteriaFuction">Criteria determine by developer to see if user should continue to play in trial mode</param>
        /// <returns></returns>
        public bool IsInTrialMode(Func<bool> additionalCriteriaFuction)
        {
            return additionalCriteriaFuction() &&
                   new LicenseInformation().IsTrial();
        }
    }
}