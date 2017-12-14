using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Context;
using DataBase.Models;

namespace DataBase.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
