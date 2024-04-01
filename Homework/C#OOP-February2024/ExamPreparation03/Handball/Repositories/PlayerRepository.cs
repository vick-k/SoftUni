using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<IPlayer> Models => models;

        public void AddModel(IPlayer model)
        {
            models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return models.Contains(GetModel(name));
        }

        public IPlayer GetModel(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            return models.Remove(GetModel(name));
        }
    }
}
