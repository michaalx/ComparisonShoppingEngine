using DataBase.Context;
using DataBase.Models;

namespace DataBase.Repositories
{
    public class StoreRepository : Repository<Store>
    {
        public StoreRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
