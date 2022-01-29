using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T obj);
        void Delete(int id);
        void Add(T obj);
    }
}
