using MediatR;

namespace Wallet.Api.Commands.RemoveFunds
{
    public class RemoveFundsRequest : IRequest<RemoveFundsResponse>
    {
        public Guid WalletId { get; set; }
        public int Amount { get; set; }
    }
}
