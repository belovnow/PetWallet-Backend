using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace AccountantAppWebAPI
{
	public interface IAccountService
	{
		Task CreateAccount(Account account, CancellationToken cancellationToken);
		IQueryable<Account> GetAccount();
		Account GetAccount(int id);
		Task DeleteAccount(int id, CancellationToken cancellationToken);
	}
}
