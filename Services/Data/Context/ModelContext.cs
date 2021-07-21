using System;
using Model;

namespace AccountantAppWebAPI
{
	public class ModelContext : IDisposable, IModelContext
	{
		private readonly ApplicationContext context;

		private GenericRepository<Account> accountRepository;

		private GenericRepository<Operation> operationRepository;

		private GenericRepository<Wallet> walletRepository;

		public ModelContext(ApplicationContext context)
		{
			this.context = context;
		}

		public void Dispose()
		{
			context?.Dispose();
		}

		public GenericRepository<Wallet> WalletRepository =>
			walletRepository ?? new GenericRepository<Wallet>(context);

		public GenericRepository<Account> AccountRepository =>
			accountRepository ?? new GenericRepository<Account>(context);

		public GenericRepository<Operation> OperationRepository =>
			operationRepository ?? new GenericRepository<Operation>(context);

		public void SaveChanges()
		{
			context.SaveChanges();
		}
	}
}
