using Microsoft.EntityFrameworkCore;
using PaySky_Bank_Task.DTOs;
using PaySky_Bank_Task.Models;

namespace PaySky_Bank_Task.Services
{
    public class AccountService : IAccountService
    {
        private readonly BankingDbContext _context;

        public AccountService(BankingDbContext context)
        {
            _context = context;
        }

        public async Task<Account> CreateAccountAsync(CreateAccountRequest request)
        {
            var account = new Account
            {
                AccountNumber = request.AccountNumber,
                Balance = request.InitialBalance,
                AccountTypeId = request.AccountTypeId
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.Include(a => a.AccountType).ToListAsync();
        }

        public async Task DepositAsync(string accountNumber, decimal amount)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) throw new Exception("Account not found");

            account.Balance += amount;

            var transaction = new Transaction
            {
                AccountId = account.Id,
                Amount = amount,
                TransactionTypeId = 1, // Deposit
                Timestamp = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task WithdrawAsync(string accountNumber, decimal amount)
        {
            var account = await _context.Accounts.Include(a => a.AccountType).FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) throw new Exception("Account not found");

            if (account.AccountType.Name == "Savings" && account.Balance < amount)
                throw new Exception("Insufficient funds for withdrawal");

            if (account.AccountType.Name == "Checking" && account.Balance + 100 < amount)
                throw new Exception("Overdraft limit exceeded");

            account.Balance -= amount;

            var transaction = new Transaction
            {
                AccountId = account.Id,
                Amount = -amount,
                TransactionTypeId = 2, // Withdrawal
                Timestamp = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task TransferAsync(string sourceAccountNumber, string targetAccountNumber, decimal amount)
        {
            await WithdrawAsync(sourceAccountNumber, amount);
            await DepositAsync(targetAccountNumber, amount);

            var sourceAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == sourceAccountNumber);

            var transaction = new Transaction
            {
                AccountId = sourceAccount.Id,
                Amount = -amount,
                TransactionTypeId = 3, // Transfer
                Timestamp = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetBalanceAsync(string accountNumber)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) throw new Exception("Account not found");

            return account.Balance;
        }
    }

}
