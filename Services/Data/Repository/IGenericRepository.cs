using System.Collections.Generic;

namespace AccountantAppWebAPI
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> GetAll();

		TEntity GetById(object id);

		void Insert(TEntity entity);

		void Update(TEntity entity);

		void Delete(object id);

		void SaveChanges();
	}
}
