namespace Model
{
	public class Wallet : IAccount
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public double Amount { get; set; }
	}
}
