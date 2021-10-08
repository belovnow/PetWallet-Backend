using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace AccountantAppWebAPI
{
	public class OperationEntityTypeConfiguration : IEntityTypeConfiguration<Operation>
	{
		public void Configure(EntityTypeBuilder<Operation> builder)
		{
			builder
				.HasOne(x => x.Wallet)
				.WithMany()
				.HasForeignKey(x => x.WalletId);
			
			builder
				.HasOne(x => x.Account)
				.WithMany()
				.HasForeignKey(x => x.AccountId);

			builder.HasData(
				new Operation
				{
					Id = 1,
					Amount = 55000,
					Executed = DateTime.Now.AddDays(-7),
					TypeEnum = OperationTypeEnum.Income,
					AccountId = 1, WalletId = 3
				}, new Operation
				{
					Id = 2,
					Amount = 124.36,
					Executed = DateTime.Now.AddDays(-3),
					TypeEnum = OperationTypeEnum.Expense,
					AccountId = 2, WalletId = 2
				}, new Operation
				{
					Id = 3,
					Amount = 3411.27,
					Executed = DateTime.Now.AddDays(-1),
					TypeEnum = OperationTypeEnum.Expense,
					AccountId = 2, WalletId = 3
				});
		}
	}
}
