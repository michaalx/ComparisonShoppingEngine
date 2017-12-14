using System.Collections.Generic;

namespace Business.Features
{
    public interface IFavoriteProducts
    {
        List<string> GetFavoriteProducts();
    }
}