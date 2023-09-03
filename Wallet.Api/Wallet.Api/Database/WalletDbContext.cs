using Microsoft.EntityFrameworkCore;
using Wallet.Api.Database.Models;

namespace Wallet.Api.Database
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Wallet>()
                   .HasMany(e => e.Transactions)
                   .WithOne(e => e.Wallet)
                   .HasForeignKey(e => e.WalletId)
                   .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
