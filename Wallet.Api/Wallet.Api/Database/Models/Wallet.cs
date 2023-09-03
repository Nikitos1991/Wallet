namespace Wallet.Api.Database.Models
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public List<Transaction> Transactions { get; set; }

        public int GetBalance()
        {
            var addFunds = Transactions?.Where(x => x.Type == TransactionType.AddFunds).Sum(x => x.Amount) ?? 0;
            var removeFunds = Transactions?.Where(x => x.Type == TransactionType.RemoveFunds).Sum(x => x.Amount) ?? 0;
            return addFunds - removeFunds;
        }
    }
}
