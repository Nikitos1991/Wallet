using MediatR;
using Wallet.Api.Database.Models;
using Wallet.Api.Database.Repositories;

namespace Wallet.Api.Commands.AddFunds
{
    public class AddFundsHandler : IRequestHandler<AddFundsRequest, AddFundsResponse>
    {
        private readonly ITransactionsRepository _transactionsRepository;

        public AddFundsHandler(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        public async Task<AddFundsResponse> Handle(AddFundsRequest request, CancellationToken cancellationToken)
        {
            var addFundsTransaction = new Transaction
            {
                Type = TransactionType.AddFunds,
                Amount = request.Amount,
                WalletId = request.WalletId
            };

            var transaction = await _transactionsRepository.CreateAsync(addFundsTransaction);

            return new AddFundsResponse
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Type = transaction.Type
            };
        }
    }
}
