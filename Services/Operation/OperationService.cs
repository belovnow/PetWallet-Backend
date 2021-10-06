using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace AccountantAppWebAPI
{
	public class OperationService : IOperationService
	{
		private readonly ApplicationContext context;

		public OperationService(ApplicationContext context)
		{
			this.context = context;
		}

		public IQueryable<Operation> GetOperations()
		{
			return context.Operations
				.Include(o => o.Account)
				.Include(o => o.Wallet)
				.AsQueryable();
		}

		public Operation GetOperation(int id)
		{
			return context.Operations.Find(id);
		}

		public async Task CreateOperation(Operation operation, CancellationToken cancellationToken)
		{
			var wallet = await context.Wallets.FindAsync(operation.WalletId, cancellationToken);
			var account = await context.Accounts.FindAsync(operation.AccountId, cancellationToken);

			if (wallet is null) throw new NullReferenceException(nameof(wallet));
			if (account is null) throw new NullReferenceException(nameof(account));
			if (operation.Type.ToString() != account.Type.ToString())
				throw new InvalidDataException(nameof(account.Type)); // возможно стоит поменять тип исключения

			switch (operation.Type)
			{
				case OperationType.Income:
					wallet.Amount += operation.Amount;
					account.Amount += operation.Amount;
					break;
				case OperationType.Expense:
					if (operation.Amount > wallet.Amount)
						throw new InvalidDataException(nameof(wallet.Amount));

					wallet.Amount -= operation.Amount;
					account.Amount += operation.Amount;
					break;
				default:
					throw new ArgumentException(nameof(operation.Type));
			}

			await context.Operations.AddAsync(operation, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteOperation(int id, CancellationToken cancellationToken)
		{
			var operation = await context.Operations.FindAsync(id, cancellationToken);
			var wallet = await context.Wallets.FindAsync(operation.WalletId, cancellationToken);
			var account = await context.Accounts.FindAsync(operation.AccountId, cancellationToken);

			switch (operation.Type)
			{
				case OperationType.Income:
					wallet.Amount -= operation.Amount;
					account.Amount -= operation.Amount;
					break;
				case OperationType.Expense:
					wallet.Amount += operation.Amount;
					account.Amount -= operation.Amount;
					break;
			}

			context.Wallets.Update(wallet);
			context.Accounts.Update(account);
			context.Operations.Remove(operation);

			await context.SaveChangesAsync(cancellationToken);
		}
	}
}
