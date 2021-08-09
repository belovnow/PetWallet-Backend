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
			modelBuilder.ApplyConfiguration(new WalletEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new OperationEntityTypeConfiguration());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.LogTo(Console.WriteLine);
		}
	}
}
