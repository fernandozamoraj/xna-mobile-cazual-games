using Microsoft.Phone.Tasks;

namespace CazualGames.MarketPlace
{
    public class  MarketPlacePurchaseService : IMarketPlacePurchaseService
    {
        /// <summary>
        /// Prompt for purchase only works in OS 7.1 or later
        /// </summary>
        /// <param name="appGuid"></param>
        public void PromptToPurchaseGame(string appGuid)
        {
            MarketplaceDetailTask fullApp = new MarketplaceDetailTask();

            fullApp.ContentIdentifier = appGuid;
            fullApp.ContentType = MarketplaceContentType.Applications;
            fullApp.Show();
        }
    }
}