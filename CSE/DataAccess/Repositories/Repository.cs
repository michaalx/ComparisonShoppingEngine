using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext _context;
        protected DbSet<T> _dbEntity;

        public Repository()
        {
            _context = new DataContext();
            _dbEntity = _context.Set<T>();
        }

        public void Delete(int id)
        {
            T entity = _dbEntity.Find(id);
            _dbEntity.Remove(entity);
        }

        public T Get(int id)
        {
            return _dbEntity.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbEntity.ToList();
        }

        public void Insert(T entity)
        {
            _dbEntity.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }

}