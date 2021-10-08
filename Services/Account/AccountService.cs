using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace AccountantAppWebAPI
{
	public class AccountService : IAccountService
	{
		private readonly ApplicationContext context;

		public AccountService(ApplicationContext context)
		{
			this.context = context;
		}

		public async Task CreateAccount(Account account, CancellationToken cancellationToken)
		{
			await context.Accounts.AddAsync(account, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
		}

		public IQueryable<Account> GetAccount()
		{
			return context.Accounts.AsQueryable();
		}

		public Account GetAccount(int id)
		{
			return context.Accounts.Find(id);
		}

		public async Task DeleteAccount(int id, CancellationToken cancellationToken)
		{
			var account = await context.Accounts.FindAsync(id, cancellationToken);
			context.Accounts.Remove(account);
			await context.SaveChangesAsync(cancellationToken);
		}
	}
}
