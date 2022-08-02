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
        private string _fullName;
        private int _combatExperience = 0;
        private ICollection<IVessel> _vessels = new List<IVessel>();

        public string FullName
        {
            get 
            {
                if(string.IsNullOrWhiteSpace(_fullName))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                return _fullName;
            }
        }
        public int CombatExperience
        {
            get { return _combatExperience; }
            set { _combatExperience = value; }
        }

        public ICollection<IVessel> Vessels
        {
            get{ return _vessels; }
            set { _vessels = value; }
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            else
            {
                Vessels.Add(vessel);
            }
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count()} vessels");

            foreach (var vessel in Vessels)
            {
                stringBuilder.AppendLine($"- {vessel.Name}");
                stringBuilder.AppendLine($" *Type: {vessel.GetType()}");
                stringBuilder.AppendLine($" *Main weapon caliber: {vessel.MainWeaponCaliber}");
                stringBuilder.AppendLine($" *Speed: {vessel.Speed} knots");
                if (vessel.Targets.Count != 0)
                {
                    stringBuilder.AppendLine($" *Targets: None");
                }
                else if (vessel.Targets.Count == 0)
                {
                    stringBuilder.AppendLine($" *Targets: {vessel.Targets}");
                }
                if (vessel is Battleship)
                {
                    if (((Battleship)vessel).SonarMode == false)
                    {
                        stringBuilder.AppendLine($" *Sonar mode: OFF");
                    }
                    if (((Battleship)vessel).SonarMode == true)
                    {
                        stringBuilder.AppendLine($" *Sonar mode: ON");
                    }
                }
                if (vessel is Submarine)
                {
                    if (((Submarine)vessel).SubmergeMode == false)
                    {
                        stringBuilder.AppendLine($" *Submerge mode: OFF");
                    }
                    if (((Submarine)vessel).SubmergeMode == true)
                    {
                        stringBuilder.AppendLine($" *Submerge mode: ON");
                    }
                }
            }    

            return stringBuilder.ToString();
        }

        public Captain(string fullName)
        {
            _fullName = fullName;
        }
    }
}
