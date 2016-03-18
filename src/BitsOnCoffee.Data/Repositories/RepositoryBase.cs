using System;
using System.Linq;
using System.Linq.Expressions;
using BitsOnCoffee.Data.Context;

namespace BitsOnCoffee.Data.Repositories
{
	public abstract class RepositoryBase : IRepositoryWithContext
	{
		protected internal IDbContext Context { get; set; }

		public abstract void Add<TEntity>(TEntity item) where TEntity : EntityBase;
		public abstract void Delete<TEntity>(long id) where TEntity : EntityBase;
		public abstract void Delete<TEntity>(TEntity item) where TEntity : EntityBase;
		public abstract void Edit<TEntity>(TEntity item) where TEntity : EntityBase;
		public abstract TEntity Get<TEntity>() where TEntity : EntityBase;
		public abstract TEntity Get<TEntity>(long id) where TEntity : EntityBase;
		public abstract TEntity Get<TEntity>(long id, params Expression<Func<TEntity, object>>[] relatedEntities) where TEntity : EntityBase;
		public abstract TResult Get<TEntity, TResult>(long id, Expression<Func<TEntity, TResult>> columns) where TEntity : EntityBase;
		public abstract IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase;
		public abstract IQueryable<TEntity> GetAll<TEntity>(params Expression<Func<TEntity, object>>[] relatedEntities) where TEntity : EntityBase;
		public abstract void Reload<TEntity>(TEntity item) where TEntity : EntityBase;
		public abstract long TotalCount<TEntity>() where TEntity : EntityBase;

		public void SetContext(IDbContext context)
		{
			this.Context = context;
		}
	}
}
