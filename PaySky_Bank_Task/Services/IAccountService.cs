using PaySky_Bank_Task.DTOs;
using PaySky_Bank_Task.Models;

namespace PaySky_Bank_Task.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(CreateAccountRequest request);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task DepositAsync(string accountNumber, decimal amount);
        Task WithdrawAsync(string accountNumber, decimal amount);
        Task TransferAsync(string sourceAccountNumber, string targetAccountNumber, decimal amount);
        Task<decimal> GetBalanceAsync(string accountNumber);
    }
}