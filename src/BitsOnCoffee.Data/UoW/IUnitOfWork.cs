using BitsOnCoffee.Data.Queries;
using BitsOnCoffee.Data.Repositories;
using System;

namespace BitsOnCoffee.Data.UoW
{
	public interface IUnitOfWork : IDisposable
	{
		TQuery CreateQuery<TQuery>() where TQuery : QueryBase;
		IRepository CreateRepository();
		int Commit();
	}
}
