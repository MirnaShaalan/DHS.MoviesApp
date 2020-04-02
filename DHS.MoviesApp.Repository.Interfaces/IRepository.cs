using DHS.MoviesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHS.MoviesApp.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
