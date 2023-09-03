using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Api.Commands.CreateWallet
{
    public class CreateWalletRequest : IRequest<CreateWalletResponse>
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(3)]
        public string Currency { get; set; }
    }
}
