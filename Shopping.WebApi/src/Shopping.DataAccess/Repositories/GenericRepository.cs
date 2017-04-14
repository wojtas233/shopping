using Shopping.DataAccess;
using Shopping.DataAccess.Entities;
using Shopping.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.DataAccess.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext context;
        private DbSet<T> entities;
        public GenericRepository(DataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void InsertRange(IEnumerable<T> range)
        {
            entities.AddRange(range);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}