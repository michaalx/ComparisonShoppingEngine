using Logic.Models;

namespace Logic.Database
{
    public interface IUpdater
    {
        int UpdatePopularityRates(Receipt receipt);
        int UpdatePrices(Receipt receipt);
    }
}