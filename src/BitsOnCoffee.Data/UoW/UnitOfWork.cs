using BitsOnCoffee.Data.Context;
using BitsOnCoffee.Data.Queries;
using BitsOnCoffee.Data.Repositories;

namespace BitsOnCoffee.Data.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private IDbContext _context;
		private IScope _scope;

		public UnitOfWork(IScope lifetimeScope)
		{
			_scope = lifetimeScope;
			_context = _scope.Resolve<IDbContext>();
		}

		public TQuery CreateQuery<TQuery>() where TQuery : QueryBase
		{
			var query = _scope.Resolve<TQuery>();
			query.Context = _context;
			return query;
		}

		public IRepository CreateRepository()
		{
			var repository = _scope.Resolve<IRepository>() as IRepositoryWithContext;
			repository.SetContext(_context);
			return repository;
		}

		public int Commit()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
			}

			if (_scope != null)
			{
				_scope.Dispose();
			}
		}
	}
}
