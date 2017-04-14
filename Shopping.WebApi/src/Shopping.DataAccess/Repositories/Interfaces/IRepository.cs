using System.Collections.Generic;
using System.Linq;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void InsertRange(IEnumerable<T> range);
        void Update(T entity);
        void Delete(T entity);
    }
}
