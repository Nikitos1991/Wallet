using MediatR;
using Wallet.Api.Commands.GetWallet;

namespace Wallet.Api.Commands.GetBalance
{
    public class GetWalletRequest : IRequest<GetWalletResponse>
    {
        public Guid WalletId { get; set; }
    }
}
