using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if (bankTypeName != "BranchBank" && bankTypeName != "CentralBank")
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank = null;

            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
            }

            banks.AddModel(bank);

            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            if (loanTypeName != "StudentLoan" && loanTypeName != "MortgageLoan")
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan loan = null;

            if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }

            loans.AddModel(loan);

            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            if (!loans.Models.Any(l => l.GetType().Name == loanTypeName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            ILoan currentLoan = loans.FirstModel(loanTypeName);
            IBank currentBank = banks.FirstModel(bankName);

            currentBank.AddLoan(currentLoan);
            loans.RemoveModel(currentLoan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (clientTypeName != "Student" && clientTypeName != "Adult")
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank currentBank = banks.FirstModel(bankName);

            if ((clientTypeName == "Student" && currentBank.GetType().Name == "CentralBank") || (clientTypeName == "Adult" && currentBank.GetType().Name == "BranchBank"))
            {
                return OutputMessages.UnsuitableBank;
            }

            IClient client = null;

            if (clientTypeName == "Student")
            {
                client = new Student(clientName, id, income);
            }
            else if (clientTypeName == "Adult")
            {
                client = new Adult(clientName, id, income);
            }

            currentBank.AddClient(client);

            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank currentBank = banks.FirstModel(bankName);

            double incomeFromClients = currentBank.Clients.Sum(c => c.Income);
            double amountFromLoans = currentBank.Loans.Sum(c => c.Amount);
            double funds = incomeFromClients + amountFromLoans;

            return $"The funds of bank {bankName} are {funds:f2}.";
        }

        public string Statistics()
        {
            StringBuilder sb = new();

            foreach (IBank bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().Trim();
        }
    }
}
