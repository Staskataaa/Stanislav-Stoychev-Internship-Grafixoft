using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models.Entities
{
    internal class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private readonly ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;
            vessels = new List<IVessel>();
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }
        public int CombatExperience
        {
            get { return combatExperience; }
            set { combatExperience = value; }
        }

        public ICollection<IVessel> Vessels
        {
            get => vessels;
        }
        //change maybe
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {this.vessels.Count} vessels.");
            if (this.Vessels.Count() > 0)
            {
                foreach (var vessel in this.vessels)
                {
                    stringBuilder.AppendLine($"{vessel}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        
    }
}
