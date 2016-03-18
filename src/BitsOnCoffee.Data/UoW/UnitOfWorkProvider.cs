using BitsOnCoffee.Data.Context;
using System.Collections.Generic;

namespace BitsOnCoffee.Data.UoW
{
	public class UnitOfWorkProvider : IUnitOfWorkProvider
	{
		private IDictionary<IScope, IUnitOfWork> _uows;
		private IScope _scope;

		public UnitOfWorkProvider(IScope scope)
		{
			_scope = scope;
			_uows = new Dictionary<IScope, IUnitOfWork>();
		}

		public IUnitOfWork CreateUoW()
		{
			var scope = _scope.BeginChildScope();
			var uow = new UnitOfWork(scope);

			_uows.Add(scope, uow);

			return uow;
		}
	}
}
