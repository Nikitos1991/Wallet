using MediatR;
using Wallet.Api.Database.Repositories;

namespace Wallet.Api.Commands.CreateWallet
{
    public class CreateWalletHandler : IRequestHandler<CreateWalletRequest, CreateWalletResponse>
    {
        private readonly IWalletsRepository _walletRepository;

        public CreateWalletHandler(IWalletsRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<CreateWalletResponse> Handle(CreateWalletRequest request, CancellationToken cancellationToken)
        {
            var model = new Database.Models.Wallet
            {
                Name = request.Name,
                Currency = request.Currency,
                Transactions = new List<Database.Models.Transaction>()
            };

            var existingWallet = await _walletRepository.GetByNameAsync(request.Name);

            if (existingWallet != null)
            {
                // custome excetption handling tbd on middlware level
                throw new Exception("Wallet already exists");
            }

            var wallet = await _walletRepository.CreateAsync(model);

            return new CreateWalletResponse
            {
                Id = wallet.Id,
                Name = wallet.Name,
                Currency = wallet.Currency,
            };
        }
    }
}
