using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace AccountantAppWebAPI
{
	public class WalletService : IWalletService
	{
		private readonly ApplicationContext context;

		public WalletService(ApplicationContext context)
		{
			this.context = context;
		}

		public async Task CreateWallet(Wallet wallet, CancellationToken cancellationToken)
		{
			await context.Wallets.AddAsync(wallet, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
		}

		public IQueryable<Wallet> GetWallets()
		{
			return context.Wallets.AsQueryable();
		}

		public Wallet GetWallet(int id)
		{
			return context.Wallets.Find(id);
		}

		public async Task DeleteWallet(int id, CancellationToken cancellationToken)
		{
			var wallet = await context.Wallets.FindAsync(id, cancellationToken);
			context.Wallets.Remove(wallet);
			await context.SaveChangesAsync(cancellationToken);
		}
	}
}
