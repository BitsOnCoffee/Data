namespace BitsOnCoffee.Data.UoW
{
	public interface IUnitOfWorkProvider
	{
		IUnitOfWork CreateUoW();
	}
}
