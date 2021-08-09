using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AccountantAppWebAPI
{
	[ApiController]
	[Route("api/accounts")]
	public class AccountController : ControllerBase
	{
		private readonly IModelContext modelContext;

		public AccountController(IModelContext modelContext)
		{
			this.modelContext =
				modelContext ?? throw new ArgumentNullException(nameof(modelContext));
		}

		[HttpGet]
		public JsonResult GetAllAccounts()
		{
			var accounts = modelContext.AccountRepository.GetAll().ToArray();

			return new JsonResult(accounts);
		}

		[HttpGet("{id}")]
		public ActionResult GetAccount(int id)
		{
			var account = modelContext.AccountRepository.GetById(id);

			return new JsonResult(account);
		}

		[HttpPost]
		public JsonResult SaveAccount(Account account)
		{
			modelContext.AccountRepository.Insert(account);
			modelContext.AccountRepository.SaveChanges();

			return new JsonResult(account);
		}

		[HttpPut("{id}")]
		public JsonResult EditAccount(Account account)
		{
			modelContext.AccountRepository.Update(account);
			modelContext.AccountRepository.SaveChanges();

			return new JsonResult(account);
		}

		[HttpDelete("{id}")]
		public JsonResult DeleteAccount(int id)
		{
			modelContext.AccountRepository.Delete(id);
			modelContext.AccountRepository.SaveChanges();

			return new JsonResult(StatusCode(200));
		}
	}
}
