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
				.HasOne<Wallet>()
				.WithMany(a => a.Operations)
				.HasForeignKey(a => a.WalletId);

			builder.HasData(
				new Operation
				{
					Id = 1,
					Amount = 55000,
					Executed = DateTime.Now.AddDays(-7),
					Type = OperationType.Income,
					AccountId = 1, WalletId = 3
				}, new Operation
				{
					Id = 2,
					Amount = 124.36,
					Executed = DateTime.Now.AddDays(-3),
					Type = OperationType.Expense,
					AccountId = 2, WalletId = 2
				}, new Operation
				{
					Id = 3,
					Amount = 3411.27,
					Executed = DateTime.Now.AddDays(-1),
					Type = OperationType.Expense,
					AccountId = 2, WalletId = 3
				});
		}
	}
}
