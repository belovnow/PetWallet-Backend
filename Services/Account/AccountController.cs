using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AccountantAppWebAPI
{
	[ApiController]
	[Route("api/accounts")]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService accountService;

		public AccountController(IAccountService accountService)
		{
			this.accountService = accountService;
		}

		[HttpGet]
		public IQueryable<Account> GetAllAccounts()
		{
			return accountService.GetAccount();
		}

		[HttpGet("{id}")]
		public Account GetAccount(int id)
		{
			return accountService.GetAccount(id);
		}

		[HttpPost]
		public async Task<Microsoft.AspNetCore.Mvc.ActionResult> SaveAccount(Account account)
		{
			await accountService.CreateAccount(account, new CancellationToken(default));

			return Ok(account);
		}

		[HttpDelete("{id}")]
		public async Task<Microsoft.AspNetCore.Mvc.ActionResult> DeleteAccount(int id)
		{
			await accountService.DeleteAccount(id, new CancellationToken(default));

			return Ok();
		}
	}
}
