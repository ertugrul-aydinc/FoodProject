using System.Linq.Expressions;

namespace CoreAndFood.Repositories.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        void Add(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        void Update(T entity);
        T Get(int id);
    }
}
