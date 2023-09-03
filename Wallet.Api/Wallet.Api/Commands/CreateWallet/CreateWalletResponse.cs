namespace Wallet.Api.Commands.CreateWallet
{
    public class CreateWalletResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
    }
}
