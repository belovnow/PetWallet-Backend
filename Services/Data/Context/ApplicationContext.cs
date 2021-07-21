using System;
using Microsoft.EntityFrameworkCore;
using Model;

namespace AccountantAppWebAPI
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}

		public DbSet<Wallet> Wallets { get; set; }

		public DbSet<Account> Accounts { get; set; }

		public DbSet<Operation> Operations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Wallet>().HasData(
				new Wallet[]
				{
					new Wallet() {Id = 1, Amount = 200, Name = "Visa"},
					new Wallet() {Id = 2, Amount = 1030.20, Name = "Наличные"},
					new Wallet() {Id = 3, Amount = 56534, Name = "PayPal"},
				});

			modelBuilder.Entity<Account>().HasData(
				new Account[]
				{
					new Account() {Id = 1, Amount = 55000, Name = "Зарплата", Type = AccountType.Income},
					new Account() {Id = 2, Amount = 3535.63, Name = "Продукты", Type = AccountType.Expense},
					new Account() {Id = 3, Amount = 0, Name = "Развлечения", Type = AccountType.Expense},
				});

			modelBuilder.Entity<Operation>().HasData(
				new Operation[]
				{
					new Operation()
					{
						Id = 1,
						Amount = 55000,
						Executed = DateTime.Now.AddDays(-7),
						Type = OperationType.Income,
						AccountId = 1, WalletId = 3
					},
					new Operation()
					{
						Id = 2,
						Amount = 124.36,
						Executed = DateTime.Now.AddDays(-3),
						Type = OperationType.Expense,
						AccountId = 2, WalletId = 2
					},
					new Operation()
					{
						Id = 3,
						Amount = 3411.27,
						Executed = DateTime.Now.AddDays(-1),
						Type = OperationType.Expense,
						AccountId = 2, WalletId = 3
					},
				});
		}
	}
}
