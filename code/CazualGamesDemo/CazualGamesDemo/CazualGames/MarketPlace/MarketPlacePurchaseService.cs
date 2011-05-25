using Microsoft.Phone.Tasks;

namespace CazualGames.MarketPlace
{
    public class  MarketPlacePurchaseService : IMarketPlacePurchaseService
    {
        public void PromptToPurchaseGame(string appGuid)
        {
            MarketplaceDetailTask fullApp = new MarketplaceDetailTask();

            fullApp.ContentIdentifier = appGuid;
            fullApp.Show();
        }
    }
}