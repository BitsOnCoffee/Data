using BitsOnCoffee.Data.UoW;

namespace BitsOnCoffee.Data.Services
{
	public abstract class ServiceBase
	{
		public IUnitOfWorkProvider provider { get; set; }
	}
}
