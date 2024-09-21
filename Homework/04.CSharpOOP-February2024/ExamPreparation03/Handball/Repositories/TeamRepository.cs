using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models;

        public TeamRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<ITeam> Models => models;

        public void AddModel(ITeam model)
        {
            models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return models.Contains(GetModel(name));
        }

        public ITeam GetModel(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            return models.Remove(GetModel(name));
        }
    }
}
