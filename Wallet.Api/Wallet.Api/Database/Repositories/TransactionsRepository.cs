using Wallet.Api.Database.Models;

namespace Wallet.Api.Database.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly WalletDbContext _dbContext;

        public TransactionsRepository(WalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
            return transaction;
        }
    }

    public interface ITransactionsRepository
    {
        Task<Transaction> CreateAsync(Transaction transaction);
    }
}
