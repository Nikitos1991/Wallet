using MediatR;
using Wallet.Api.Database.Models;
using Wallet.Api.Database.Repositories;

namespace Wallet.Api.Commands.RemoveFunds
{
    public class RemoveFundsHandlers : IRequestHandler<RemoveFundsRequest, RemoveFundsResponse>
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IWalletsRepository _walletRepository;

        public RemoveFundsHandlers(ITransactionsRepository transactionsRepository, IWalletsRepository walletRepository)
        {
            _transactionsRepository = transactionsRepository;
            _walletRepository = walletRepository;
        }

        public async Task<RemoveFundsResponse> Handle(RemoveFundsRequest request, CancellationToken cancellationToken)
        {
            var removeFundsTransaction = new Transaction
            {
                Type = TransactionType.RemoveFunds,
                Amount = request.Amount,
                WalletId = request.WalletId
            };

            var wallet = await _walletRepository.GetAsync(request.WalletId);
            var balance = wallet.GetBalance();
            if (balance - request.Amount < 0)
            {
                throw new Exception("Balance can't be negative");
            }

            var transaction = await _transactionsRepository.CreateAsync(removeFundsTransaction);

            return new RemoveFundsResponse
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Type = transaction.Type
            };
        }
    }
}
