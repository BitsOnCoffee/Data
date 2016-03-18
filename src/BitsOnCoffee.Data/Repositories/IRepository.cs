using BitsOnCoffee.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BitsOnCoffee.Data.Repositories
{
	public interface IRepository
	{
		/// <summary>
		/// Adds the entity into the Unit of Work.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <param name="item">Instance of entity to be added</param>
		void Add<TEntity>(TEntity item) where TEntity : EntityBase;

		/// <summary>
		/// Sets the entity as deleted.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <param name="item">Instance of entity to be deleted</param>
		void Delete<TEntity>(TEntity item) where TEntity : EntityBase;

		/// <summary>
		/// Sets the entity as deleted.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <param name="id">Id of the Entity</param>
		void Delete<TEntity>(long id) where TEntity : EntityBase;

		/// <summary>
		/// Sets the entity as changed.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <param name="item">Instance of entity to be edited</param>
		void Edit<TEntity>(TEntity item) where TEntity : EntityBase;

		/// <summary>
		/// Gets the first entity or null.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <returns>Entity or null</returns>
		TEntity Get<TEntity>() where TEntity : EntityBase;

		/// <summary>
		/// Gets the entity by Id.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <param name="id">Id of the Entity</param>
		/// <returns>Entity</returns>
		TEntity Get<TEntity>(long id) where TEntity : EntityBase;

		/// <summary>
		/// Gets the entity by Id and loads related entities passed as parameter.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <param name="id">Id of the Entity</param>
		/// <param name="relatedEntities">Related entities to be loaded</param>
		/// <returns>Entity</returns>
		TEntity Get<TEntity>(long id, params Expression<Func<TEntity, object>>[] relatedEntities) where TEntity : EntityBase;

		/// <summary>
		/// Gets the entity by Id and select only certain columns.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <typeparam name="TResult">Class of the object that will be returned</typeparam>
		/// <param name="id">Id of the Entity</param>
		/// <param name="columns">Columns to be loaded</param>
		/// <returns>Entity</returns>
		TResult Get<TEntity, TResult>(long id, Expression<Func<TEntity, TResult>> columns) where TEntity : EntityBase;

		/// <summary>
		/// Gets all entities.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <returns>Collection of entities</returns>
		IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase;

		/// <summary>
		/// Gets all entities and loads related entities passed as parameter.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <param name="relatedEntities">Related entities to be loaded</param>
		/// <returns>Collection of entities</returns>
		IQueryable<TEntity> GetAll<TEntity>(params Expression<Func<TEntity, object>>[] relatedEntities) where TEntity : EntityBase;

		/// <summary>
		/// Reloads the entity, rewrites all properties by the values loaded from the data storage.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <param name="item">Entity to be reloaded</param>
		void Reload<TEntity>(TEntity item) where TEntity : EntityBase;

		/// <summary>
		/// Returns the total count of entities.
		/// </summary>
		/// <typeparam name="TEntity">Entity inherited from EntityBase</typeparam>
		/// <returns>Number of entities</returns>
		long TotalCount<TEntity>() where TEntity : EntityBase;
	}

	internal interface IRepositoryWithContext : IRepository
	{
		void SetContext(IDbContext context);
	}
}