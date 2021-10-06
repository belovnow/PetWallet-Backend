using System;

namespace Model
{
	public class Operation
	{
		public int Id { get; set; }

		public OperationType Type { get; set; }

		public double Amount { get; set; }

		public DateTime Executed { get; set; }

		public Wallet Wallet { get; set; }

		public int WalletId { get; set; }

		public Account Account { get; set; }

		public int AccountId { get; set; }
	}
}
