using BitsOnCoffee.Data.Context;

namespace BitsOnCoffee.Data.Queries
{
	public abstract class QueryBase
	{
		protected internal IDbContext Context { get; set; }
	}

	public abstract class QueryBase<TEntity, TReturn> : QueryBase where TEntity : EntityBase
	{
		protected abstract TReturn CreateQuery();

		public TReturn Execute()
		{
			var query = CreateQuery();
			return query;
		}
	}
}
