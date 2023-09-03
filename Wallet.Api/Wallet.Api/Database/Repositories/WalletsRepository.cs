namespace Wallet.Api.Database.Repositories
{
    public class WalletsRepository : IWalletsRepository
    {
        public WalletsRepository()
        {

        }

        public async Task<Models.Wallet> CreateAsync(Models.Wallet wallet)
        {
            return await Task.FromResult(new Models.Wallet { });
        }

        public async Task<Models.Wallet> GetAsync(Guid Id)
        {
            return await Task.FromResult(new Models.Wallet { });
        }

        public async Task<Models.Wallet> GetByNameAsync(string name)
        {
            return await Task.FromResult(new Models.Wallet { });
        }
    }

    public interface IWalletsRepository
    {
        Task<Models.Wallet> CreateAsync(Models.Wallet wallet);
        Task<Models.Wallet> GetAsync(Guid Id);
        Task<Models.Wallet> GetByNameAsync(string name);
    }
}
