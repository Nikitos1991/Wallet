using MediatR;
using Wallet.Api.Commands.GetBalance;
using Wallet.Api.Database.Repositories;

namespace Wallet.Api.Commands.GetWallet
{
    public class GetWalletHandler : IRequestHandler<GetWalletRequest, GetWalletResponse>
    {
        private readonly IWalletsRepository _walletRepository;
        public GetWalletHandler(IWalletsRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<GetWalletResponse> Handle(GetWalletRequest request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetAsync(request.WalletId);
            if (wallet == null)
            {
                throw new Exception("Wallet was not found");
            }

            return new GetWalletResponse
            {
                Name = wallet.Name,
                Currency = wallet.Currency,
                Balance = wallet.GetBalance()
            };
        }
    }
}
