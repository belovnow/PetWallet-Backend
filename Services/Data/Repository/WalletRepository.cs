using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace AccountantAppWebAPI
{
	public class WalletRepository : GenericRepository<Wallet>
	{
		private readonly ApplicationContext context;

		public override IEnumerable<Wallet> GetAll()
		{
			return context.Wallets.Include(o => o.Operations);
		}

		public override Wallet GetById(object id)
		{
			return context
				.Wallets
				.Include(w => w.Operations)
				.SingleOrDefault(w => w.Id == (int) id);
		}

		public WalletRepository(ApplicationContext context) : base(context)
		{
			this.context = context;
		}
	}
}
