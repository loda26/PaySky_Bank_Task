namespace PaySky_Bank_Task.DTOs
{
    public class TransferRequest
    {
        public string SourceAccountNumber { get; set; } = string.Empty;
        public string TargetAccountNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}