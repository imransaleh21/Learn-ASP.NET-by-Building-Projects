namespace _4_Bank_Apps_Using_Controller.Models
{
    public class Accounts
    {
        public required string AccountNumber { get; set; }
        public string? Name { get; set; }
        public required double Balance { get; set; }
        public required string AccountType { get; set; }
    }
}
