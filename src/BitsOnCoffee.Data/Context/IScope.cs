using System;

namespace BitsOnCoffee.Data.Context
{
	public interface IScope : IDisposable
	{
		IScope BeginChildScope();
		T Resolve<T>();
	}
}
