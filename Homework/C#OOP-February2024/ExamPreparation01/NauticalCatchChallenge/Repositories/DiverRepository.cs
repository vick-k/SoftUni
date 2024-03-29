﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> models;

        public DiverRepository()
        {
            models = new List<IDiver>();
        }

        public IReadOnlyCollection<IDiver> Models { get => models; }

        public void AddModel(IDiver model)
        {
            models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }
    }
}
