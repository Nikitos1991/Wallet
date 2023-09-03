namespace Wallet.Api.Commands.GetWallet
{
    public class GetWalletResponse
    {
        public string Name { get; set; }
        public string Currency { get; set; }
        public int Balance { get; set; }
    }
}
