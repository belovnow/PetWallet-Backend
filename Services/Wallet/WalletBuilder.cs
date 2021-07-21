using System.Linq;

namespace AccountantAppWebAPI
{
	public static class WalletBuilder
	{
		public static void CascadeDeleteWallets(IModelContext modelContext, int id)
		{
			var operations = modelContext.OperationRepository.GetAll();

			var selectedOperations = operations
				.Where(op => op.WalletId == id)
				.ToArray();

			foreach (var operation in selectedOperations) modelContext.OperationRepository.Delete(operation.Id);

			modelContext.OperationRepository.SaveChanges();
		}
	}
}
