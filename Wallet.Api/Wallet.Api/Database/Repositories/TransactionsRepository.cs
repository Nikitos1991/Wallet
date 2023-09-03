using Wallet.Api.Database.Models;

namespace Wallet.Api.Database.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        public TransactionsRepository()
        {

        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            return await Task.FromResult(new Transaction());
        }

        public async Task<IEnumerable<Transaction>> GetByWalletIdAsync(Guid walletId)
        {
            return await Task.FromResult(new List<Transaction>());
        }
    }

    public interface ITransactionsRepository
    {
        Task<Transaction> CreateAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetByWalletIdAsync(Guid walletId);
    }
}
