using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new();
            clients = new();
        }

        public string Name // All names are unique
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => loans;

        public IReadOnlyCollection<IClient> Clients => clients;

        public double SumRates()
        {
            return loans.Sum(l => l.InterestRate);
        }

        public void AddClient(IClient Client)
        {
            if (clients.Count >= Capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            clients.Add(Client);
        }

        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");

            if (clients.Count == 0)
            {
                sb.AppendLine("Clients: none");
            }
            else
            {
                List<string> clientNames = new();

                foreach (IClient client in clients)
                {
                    clientNames.Add(client.Name);
                }

                sb.AppendLine($"Clients: {string.Join(", ", clientNames)}");
            }

            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().Trim();
        }
    }
}
