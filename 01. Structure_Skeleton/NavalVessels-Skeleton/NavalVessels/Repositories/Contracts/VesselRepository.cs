using NavalVessels.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories.Contracts
{
    internal class VesselRepository : IRepository<Vessel>
    {
        private List<Vessel> _models;

        public IReadOnlyCollection<Vessel> Models
        {
            get { return _models; }
        }

        public void Add(Vessel model)
        {
            _models.Add(model);
            _models.Distinct();
        }

        public Vessel FindByName(string name)
        {
            return _models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(Vessel model)
        {
            return _models.Remove(model);
        }
    }
}
