using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> models;

        public BankRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<IBank> Models => models;

        public void AddModel(IBank model)
        {
            models.Add(model);
        }

        public bool RemoveModel(IBank model)
        {
            return models.Remove(model);
        }

        public IBank FirstModel(string name)
        {
            return models.FirstOrDefault(b => b.Name == name);
        }
    }
}
