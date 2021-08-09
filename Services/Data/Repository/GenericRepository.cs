using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AccountantAppWebAPI
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly ApplicationContext context;

		private readonly DbSet<TEntity> dbSet;

		public GenericRepository(ApplicationContext context)
		{
			this.context = context;
			dbSet = context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return dbSet.ToList();
		}

		public virtual TEntity GetById(object id)
		{
			return dbSet.Find(id);
		}

		public void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public void Update(TEntity entity)
		{
			dbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}

		public void Delete(object id)
		{
			var existing = dbSet.Find(id);
			dbSet.Remove(existing);
		}

		public void SaveChanges()
		{
			context.SaveChanges();
		}
	}
}
