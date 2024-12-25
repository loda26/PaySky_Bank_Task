namespace PaySky_Bank_Task.DTOs
{
    public class CreateAccountRequest
    {
        public string AccountNumber { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; }
        public int AccountTypeId { get; set; }
    }
}