using Wallet.Api.Database.Models;

namespace Wallet.Api.Commands.AddFunds
{
    public class AddFundsResponse
    {
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public int Amount { get; set; }
    }
}
