using System.Linq;

namespace AccountantAppWebAPI
{
	public static class AccountBuilder
	{
		public static void CascadeDeleteAccounts(IModelContext modelContext, int id)
		{
			var operations = modelContext.OperationRepository.GetAll();

			var selectedOperations = operations
				.Where(op => op.AccountId == id)
				.ToArray();

			foreach (var operation in selectedOperations)
			{
				modelContext.OperationRepository.Delete(operation.Id);
			}

			modelContext.OperationRepository.SaveChanges();
		}
	}
}
