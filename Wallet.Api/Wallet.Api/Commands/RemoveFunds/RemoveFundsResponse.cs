using Wallet.Api.Database.Models;

namespace Wallet.Api.Commands.RemoveFunds
{
    public class RemoveFundsResponse
    {
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public int Amount { get; set; }
    }
}
