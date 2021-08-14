using System;
using System.IO;
using Model;

namespace AccountantAppWebAPI
{
	public class OperationRepository : GenericRepository<Operation>
	{
		private readonly ApplicationContext context;

		public OperationRepository(ApplicationContext context) : base(context)
		{
			this.context = context;
		}

		public override void Insert(Operation entity)
		{
			var wallet = context.Wallets.Find(entity.WalletId);
			var account = context.Accounts.Find(entity.AccountId);

			if (wallet is null) throw new NullReferenceException(nameof(wallet));
			if (account is null) throw new NullReferenceException(nameof(account));
			if (entity.Type.ToString() != account.Type.ToString())
				throw new InvalidDataException(nameof(account.Type));

			switch (entity.Type)
			{
				case OperationType.Income:
					wallet.Amount += entity.Amount;
					account.Amount += entity.Amount;
					break;
				case OperationType.Expense:
					if (entity.Amount > wallet.Amount)
						throw new InvalidDataException(nameof(wallet.Amount));

					wallet.Amount -= entity.Amount;
					account.Amount += entity.Amount;
					break;
				default:
					throw new ArgumentException(nameof(entity.Type));
			}

			context.Operations.Add(entity);
		}

		public override void Delete(object id)
		{
			var operation = context.Operations.Find(id);
			var wallet = context.Wallets.Find(operation.WalletId);
			var account = context.Accounts.Find(operation.AccountId);

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
		}
	}
}
