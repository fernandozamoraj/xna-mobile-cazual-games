using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CazualGames.Licensing
{
    public interface ILicensingService
    {
        bool IsInTrialMode(Func<bool> isInTrialMode);
    }
}
