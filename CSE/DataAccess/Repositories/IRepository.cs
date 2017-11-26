using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();
    }
}
