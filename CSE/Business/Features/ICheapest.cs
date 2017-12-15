using System.Collections.Generic;

namespace Business.Features
{
    public interface ICheapest
    {
        Dictionary<string, decimal> GetCheapest(List<string> products);
        List<string> GetProducts();
    }
}
