using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace AccountantAppWebAPI
{
	public class WalletEntityTypeConfiguration : IEntityTypeConfiguration<Wallet>
	{
		public void Configure(EntityTypeBuilder<Wallet> builder)
		{
			builder.HasData(
				new Wallet {Id = 1, Amount = 200, Name = "Visa"},
				new Wallet {Id = 2, Amount = 1030.20, Name = "Наличные"},
				new Wallet {Id = 3, Amount = 56534, Name = "PayPal"});
		}
	}
}
