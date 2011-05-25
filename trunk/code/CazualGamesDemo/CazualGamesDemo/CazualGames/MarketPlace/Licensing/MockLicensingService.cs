using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CazualGames.Licensing
{
    public class MockLicensingService: ILicensingService
    {
        public bool IsInTrialMode(Func<bool> isInTrialMode)
        {
            return isInTrialMode();
        }
    }
}
