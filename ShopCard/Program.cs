namespace ShopCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank<BankPremium> bank = new Bank<BankPremium>();
            bank.GetMoney(2000);
        }
    }
}
