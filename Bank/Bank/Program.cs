namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Yana",100000000000);
            BankAccount account2 = new BankAccount("Lena", 100);
            Console.WriteLine
                ($"account:  {account1.Owner} {account1.Balance} {account1.Number}");
            Console.WriteLine
                ($"account: {account2.Owner} {account2.Balance} {account2.Number}");
            
            account1.MakeDeposit(1000, DateTime.UtcNow, ":)");
            Console.WriteLine(account1.Balance);
            
            account1.MakeWithdrawal(100, DateTime.UtcNow, ":(");
            Console.WriteLine(account1.Balance);

            
            Console.WriteLine(account1.GetAccountHistory());

            try
            {
                account2.MakeWithdrawal(1000, DateTime.UtcNow, "&&&");
                Console.WriteLine(account2.Balance);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            InterestEarningAccount interest = new InterestEarningAccount("Pupu", 1000);
            interest.PerformMonthAndTransactions();

            Console.WriteLine(interest.GetAccountHistory());
            LineOfCreditAccount lineOfCredit = new LineOfCreditAccount("Pupu", 10);

            List<BankAccount> accounts = new List<BankAccount>();//создали список из разных
            accounts.Add(account1);
            accounts.Add(interest);
            accounts.Add(lineOfCredit);

            foreach(BankAccount account in accounts)
            {
                account.PerformMonthAndTransactions();//вызывается привязанный к тому какой объект пришел
                Console.WriteLine(account.GetAccountHistory());
            }

        }
    }
}
