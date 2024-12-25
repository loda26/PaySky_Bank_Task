namespace PaySky_Bank_Task.DTOs
{
    public class DepositRequest
    {
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}