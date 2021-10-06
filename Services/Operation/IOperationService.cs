using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountantAppWebAPI.ViewModel;
using Model;

namespace AccountantAppWebAPI
{
	public interface IOperationService
	{
		IQueryable<Operation> GetOperations();
		Operation GetOperation(int id);
		Task CreateOperation(Operation operation, CancellationToken cancellationToken);
		Task DeleteOperation(int id, CancellationToken cancellationToken);
	}
}
