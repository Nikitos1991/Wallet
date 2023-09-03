using MediatR;

namespace Wallet.Api.Commands.AddFunds
{
    public class AddFundsRequest : IRequest<AddFundsResponse>
    {
        public int Amount { get; set; }
        public Guid WalletId { get; set; }
    }
}
