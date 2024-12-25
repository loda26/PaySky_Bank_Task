using Microsoft.EntityFrameworkCore;
using PaySky_Bank_Task.Models;

public class BankingDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }

    public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountType>().HasData(
            new AccountType { Id = 1, Name = "Checking" },
            new AccountType { Id = 2, Name = "Savings" }
        );

        modelBuilder.Entity<TransactionType>().HasData(
            new TransactionType { Id = 1, Name = "Deposit" },
            new TransactionType { Id = 2, Name = "Withdrawal" },
            new TransactionType { Id = 3, Name = "Transfer" }
        );
    }
}