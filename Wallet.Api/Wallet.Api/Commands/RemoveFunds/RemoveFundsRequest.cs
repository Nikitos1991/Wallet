using MediatR;
using System.Text.Json.Serialization;

namespace Wallet.Api.Commands.RemoveFunds
{
    public class RemoveFundsRequest : IRequest<RemoveFundsResponse>
    {
        [JsonIgnore]
        public Guid WalletId { get; set; }
        public int Amount { get; set; }
    }
}
