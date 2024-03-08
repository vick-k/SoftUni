namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new();

            string[] accountsInfo = Console.ReadLine().Split(',');

            foreach (string account in accountsInfo)
            {
                string[] arguments = account.Split("-");
                int accountNumber = int.Parse(arguments[0]);
                double accountBalance = double.Parse(arguments[1]);

                accounts.Add(accountNumber, accountBalance);
            }

            string commandInfo;
            while ((commandInfo = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] arguments = commandInfo.Split();
                    string command = arguments[0];

                    if (command != "Deposit" && command != "Withdraw")
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    int accountNumber = int.Parse(arguments[1]);

                    if (!accounts.ContainsKey(accountNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    double sum = double.Parse(arguments[2]);

                    if (command == "Deposit")
                    {
                        accounts[accountNumber] += sum;
                    }
                    else if (command == "Withdraw")
                    {
                        if (sum > accounts[accountNumber])
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        accounts[accountNumber] -= sum;
                    }

                    Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
