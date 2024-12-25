using Microsoft.AspNetCore.Mvc;
using PaySky_Bank_Task.DTOs;
using PaySky_Bank_Task.Services;

namespace PaySky_Bank_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            var account = await _accountService.CreateAccountAsync(request);
            return CreatedAtAction(nameof(GetAllAccounts), new { id = account.Id }, account);
        }


        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            await _accountService.DepositAsync(request.AccountNumber, request.Amount);
            return Ok("Deposit successful");
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
        {
            await _accountService.WithdrawAsync(request.AccountNumber, request.Amount);
            return Ok("Withdrawal successful");
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            await _accountService.TransferAsync(request.SourceAccountNumber, request.TargetAccountNumber, request.Amount);
            return Ok("Transfer successful");
        }

        [HttpGet("{accountNumber}/balance")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            var balance = await _accountService.GetBalanceAsync(accountNumber);
            return Ok(balance);
        }
    }

}
