using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AccountantAppWebAPI
{
	[ApiController]
	[Route("api/wallets")]
	public class WalletController : ControllerBase
	{
		private readonly IModelContext modelContext;

		public WalletController(IModelContext modelContext)
		{
			this.modelContext =
				modelContext ?? throw new ArgumentNullException(nameof(modelContext));
		}

		[HttpGet]
		public JsonResult GetWallets()
		{
			var wallets = modelContext.WalletRepository.GetAll().ToArray();

			return new JsonResult(wallets);
		}

		[HttpGet("{id}")]
		public ActionResult GetWallet(int id)
		{
			var wallet = modelContext.WalletRepository.GetById(id);

			return new JsonResult(wallet);
		}

		[HttpPost]
		public JsonResult SaveWallet(Wallet wallet)
		{
			modelContext.WalletRepository.Insert(wallet);
			modelContext.SaveChanges();

			return new JsonResult(wallet);
		}

		[HttpPut("{id}")]
		public JsonResult EditWallet(Wallet wallet)
		{
			modelContext.WalletRepository.Update(wallet);
			modelContext.SaveChanges();

			return new JsonResult(wallet);
		}

		[HttpDelete("{id}")]
		public JsonResult DeleteWallet(int id)
		{
			WalletBuilder.CascadeDeleteWallets(modelContext, id);

			modelContext.WalletRepository.Delete(id);
			modelContext.SaveChanges();

			return new JsonResult(StatusCode(200));
		}
	}
}
