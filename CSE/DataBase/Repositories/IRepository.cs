using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task Insert(T entity);
        void Delete(T id);
        void DeleteAt(int id);
        Task Save();
    }
}
