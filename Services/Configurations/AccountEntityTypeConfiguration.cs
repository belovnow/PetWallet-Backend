using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace AccountantAppWebAPI
{
	public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.HasData(
				new Account {Id = 1, Amount = 55000, Name = "Зарплата", Type = AccountType.Income},
				new Account {Id = 2, Amount = 3535.63, Name = "Продукты", Type = AccountType.Expense},
				new Account {Id = 3, Amount = 0, Name = "Развлечения", Type = AccountType.Expense});
		}
	}
}
