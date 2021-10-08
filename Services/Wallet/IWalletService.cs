using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace AccountantAppWebAPI
{
	public interface IWalletService
	{
		Task CreateWallet(Wallet wallet, CancellationToken cancellationToken);
		IQueryable<Wallet> GetWallets();
		Wallet GetWallet(int id);
		Task DeleteWallet(int id, CancellationToken cancellationToken);
	}
}
