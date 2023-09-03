using MediatR;

namespace Wallet.Api.Commands.CreateWallet
{
    public class CreateWalletRequest : IRequest<CreateWalletResponse>
    {
        public string Name { get; set; }
        public string Currency { get; set; }
    }
}
