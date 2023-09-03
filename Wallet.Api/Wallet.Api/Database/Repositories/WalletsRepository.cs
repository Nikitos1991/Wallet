using Microsoft.EntityFrameworkCore;

namespace Wallet.Api.Database.Repositories
{
    public class WalletsRepository : IWalletsRepository
    {
        private readonly WalletDbContext _dbContext;

        public WalletsRepository(WalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.Wallet> CreateAsync(Models.Wallet wallet)
        {
            await _dbContext.Wallets.AddAsync(wallet);
            await _dbContext.SaveChangesAsync();
            return wallet;
        }

        public async Task<Models.Wallet?> GetAsync(Guid id)
        {
            return await _dbContext.Wallets.Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Wallet?> GetByNameAsync(string name)
        {
            return await _dbContext.Wallets.FirstOrDefaultAsync(x => x.Name == name);
        }
    }

    public interface IWalletsRepository
    {
        Task<Models.Wallet> CreateAsync(Models.Wallet wallet);
        Task<Models.Wallet?> GetAsync(Guid Id);
        Task<Models.Wallet?> GetByNameAsync(string name);
    }
}
