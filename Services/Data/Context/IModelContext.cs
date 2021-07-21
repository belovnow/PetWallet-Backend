using Model;

namespace AccountantAppWebAPI
{
	public interface IModelContext
	{
		GenericRepository<Wallet> WalletRepository { get; }

		GenericRepository<Account> AccountRepository { get; }

		GenericRepository<Operation> OperationRepository { get; }

		void SaveChanges();

		void Dispose();
	}
}
