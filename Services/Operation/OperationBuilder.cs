using System;
using System.IO;
using Model;

namespace AccountantAppWebAPI
{
	public static class OperationBuilder
	{
		public static void CreateOperation(IModelContext modelContext, Operation operation)
		{
			var account = modelContext.AccountRepository.GetById(operation.AccountId);
			var wallet = modelContext.WalletRepository.GetById(operation.WalletId);

			switch (operation.Type)
			{
				case OperationType.Income:
					if (account.Type is AccountType.Expense)
					{
						throw new InvalidDataException(nameof(account.Type));
					}

					wallet.Amount += operation.Amount;
					account.Amount += operation.Amount;

					break;
				case OperationType.Expense:
					if (account.Type is AccountType.Income)
					{
						throw new InvalidDataException(nameof(account.Type));
					}

					if (operation.Amount > wallet.Amount)
					{
						throw new ArgumentException(nameof(wallet.Amount));
					}

					wallet.Amount -= operation.Amount;
					account.Amount += operation.Amount;

					break;
				default:
					throw new ArgumentException(nameof(operation.Type));
			}

			modelContext.WalletRepository.Update(wallet);
			modelContext.AccountRepository.Update(account);
		}

		public static void DeleteOperation(IModelContext modelContext, int id)
		{
			var operation = modelContext.OperationRepository.GetById(id);
			var account = modelContext.AccountRepository.GetById(operation.AccountId);
			var wallet = modelContext.WalletRepository.GetById(operation.WalletId);

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

			modelContext.WalletRepository.Update(wallet);
			modelContext.AccountRepository.Update(account);
		}
	}
}
