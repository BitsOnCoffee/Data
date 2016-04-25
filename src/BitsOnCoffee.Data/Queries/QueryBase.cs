using BitsOnCoffee.Data.Context;
using BitsOnCoffee.Data.StoredProcedures;
using System.Collections;
using System.Collections.Generic;

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

	public abstract class QueryBase<TStoredProcedure> : QueryBase where TStoredProcedure : StoredProcedureBase
	{
		protected abstract IList<TStoredProcedure> CreateQuery();

		public IList<TStoredProcedure> Execute()
		{
			var query = CreateQuery();
			return query;
		}
	}
}
