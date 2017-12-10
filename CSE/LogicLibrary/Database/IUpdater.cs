using LogicLibrary.Models;

namespace LogicLibrary.Database
{
    public interface IUpdater
    {
        int UpdatePopularityRates(Receipt receipt);
        int UpdatePrices(Receipt receipt);
    }
}