namespace Wallet.Api.Database.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public int Amount { get; set; }
        public Guid WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
