using CoreAndFood.Contexts;
using CoreAndFood.Models;
using CoreAndFood.Models.Common;
using CoreAndFood.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : BaseEntity,new()
	{
		Context _context = new Context();

		//public GenericRepository(Context context)
		//{
		//	_context = context;
		//}

		public List<T> GetAll(Expression<Func<T,bool>> filter = null)
		{
			return filter == null ? _context.Set<T>().ToList() : _context.Set<T>().Where(filter).ToList();
		}

		public async void Add(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
			_context.SaveChanges();
		}
		public T Get(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> GetAll(string p)
		{
			return _context.Set<T>().Include(p).ToList();
		}

        public void DeleteById(int id)
        {
			var deletedEntity = _context.Set<T>().Find(id);

			_context.Set<T>().Remove(deletedEntity);
			_context.SaveChanges();
        }
    }
}
