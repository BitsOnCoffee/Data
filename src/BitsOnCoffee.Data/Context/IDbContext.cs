using BitsOnCoffee.Data.StoredProcedures;
using System;
using System.Collections.Generic;

namespace BitsOnCoffee.Data.Context
{
	public interface IDbContext : IDisposable
	{
		IList<T> CallStoredProcedure<T>(T storedProcedure) where T : StoredProcedureBase;
		int SaveChanges();
	}
}
