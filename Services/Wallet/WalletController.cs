using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AccountantAppWebAPI
{
	[ApiController]
	[Route("api/wallets")]
	public class WalletController : ControllerBase
	{
		private readonly IWalletService walletService;

		public WalletController(IWalletService walletService)
		{
			this.walletService = walletService;
		}

		[HttpGet]
		public IQueryable<Wallet> GetWallets()
		{
			return walletService.GetWallets();
		}

		[HttpGet("{id}")]
		public Wallet GetWallet(int id)
		{
			return walletService.GetWallet(id);
		}

		[HttpPost]
		public async Task<Microsoft.AspNetCore.Mvc.ActionResult> SaveWallet(Wallet wallet)
		{
			await walletService.CreateWallet(wallet, new CancellationToken(default));

			return Ok(wallet);
		}

		[HttpDelete("{id}")]
		public async Task DeleteWallet(int id)
		{
			await walletService.DeleteWallet(id, new CancellationToken(default));
		}
	}
}
