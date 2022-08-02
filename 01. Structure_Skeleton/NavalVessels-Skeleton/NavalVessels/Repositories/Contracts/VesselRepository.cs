using NavalVessels.Models.Contracts;
using NavalVessels.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories.Contracts
{
    internal class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> _models;

        public IReadOnlyCollection<IVessel> Models
        {
            get { return _models; }
        }

        public void Add(IVessel model)
        {
            _models.Add(model);
            _models.Distinct();
        }

        public IVessel FindByName(string name)
        {
            return _models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            return _models.Remove(model);
        }
    }
}
