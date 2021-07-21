namespace Model
{
	public class Account : IAccount
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public double Amount { get; set; }

		public AccountType Type { get; set; }
	}
}
