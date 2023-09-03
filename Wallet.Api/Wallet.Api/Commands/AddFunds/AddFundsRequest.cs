using MediatR;
using System.Text.Json.Serialization;

namespace Wallet.Api.Commands.AddFunds
{
    public class AddFundsRequest : IRequest<AddFundsResponse>
    {
        public int Amount { get; set; }
        [JsonIgnore]
        public Guid WalletId { get; set; }
    }
}
