using System;
using Model;

namespace AccountantAppWebAPI
{
	public class ModelContext : IDisposable, IModelContext
	{
		private readonly ApplicationContext context;

		public ModelContext(ApplicationContext context)
		{
			this.context = context;
			WalletRepository = new WalletRepository(context);
			AccountRepository = new GenericRepository<Account>(context);
			OperationRepository = new GenericRepository<Operation>(context);
		}

		public WalletRepository WalletRepository { get; }

		public GenericRepository<Account> AccountRepository { get; }

		public GenericRepository<Operation> OperationRepository { get; }

		public void SaveChanges()
		{
			context.SaveChanges();
		}

		public void Dispose()
		{
			context?.Dispose();
		}
	}
}
