using System;

namespace BitsOnCoffee.Data.Context
{
	public interface IDbContext : IDisposable
	{
		int SaveChanges();
	}
}
