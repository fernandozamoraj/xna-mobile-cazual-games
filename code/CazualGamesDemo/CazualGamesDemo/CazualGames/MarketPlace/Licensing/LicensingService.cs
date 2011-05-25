using System;
using Microsoft.Phone.Marketplace;

namespace CazualGames.Licensing
{
    public class LicensingService : ILicensingService
    {
        /// <summary>
        /// Checks to see if the program is in trial mode
        /// </summary>
        /// <param name="isInTrialMode">Check for level or time to see if the player is at the point to stop in trial mode</param>
        /// <returns></returns>
        public bool IsInTrialMode(Func<bool> isInTrialMode)
        {
            return isInTrialMode() &&
                   new LicenseInformation().IsTrial();
        }
    }
}