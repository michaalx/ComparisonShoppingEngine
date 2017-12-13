using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext Context;
        protected DbSet<T> Entity;

        public Repository(DataContext context)
        {
            Context = context;
            Entity = Context.Set<T>();
        }

        public Task<T> Get(int id)
        {
            return Entity.FindAsync(id);
        }

        public Task<List<T>> GetAll()
        {
            return Entity.ToListAsync();
        }

        public Task Insert(T entity)
        {
            return Entity.AddAsync(entity);
        }

        public void InsertRange(List<T> listOfEntities)
        {
            Debug.WriteLine("Bandom is naujo!");
            Entity.AddRange(listOfEntities);
        }

        public void Delete(T id)
        {
            Entity.Remove(id);
        }

        public void DeleteAt(int id)
        {
            var itemToRemove = Entity.Find(id);
            Entity.Remove(itemToRemove);
        }

        public Task Save()
        {
            return Context.SaveChangesAsync();
        }
    }
}
