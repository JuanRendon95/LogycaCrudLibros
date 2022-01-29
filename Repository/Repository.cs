using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibroContext _dbcontext;
        private DbSet<T> _table;

        public Repository(LibroContext dbcontext)
        {
            _dbcontext = dbcontext;
            _table = _dbcontext.Set<T>();
        }

        public void Delete(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public void Add(T obj)
        {
            _table.Add(obj);
            _dbcontext.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _dbcontext.Entry(obj).State = EntityState.Modified;
            _dbcontext.SaveChanges();
        }
    }
}
