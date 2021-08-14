using Model;

namespace AccountantAppWebAPI
{
	public interface IModelContext
	{
		WalletRepository WalletRepository { get; }

		GenericRepository<Account> AccountRepository { get; }

		OperationRepository OperationRepository { get; }

		void SaveChanges();

		void Dispose();
	}
}
