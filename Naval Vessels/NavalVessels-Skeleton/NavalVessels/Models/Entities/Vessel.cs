using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models.Entities
{
    internal abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private readonly List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                name = value;
            }
        }
        public ICaptain Captain
        {
            get
            {
                return captain;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainName);
                }
                captain = value;
            }
        }

        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value;  }
        }

        public ICollection<string> Targets
        {
            get { return targets; }
        }
       
        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            targets.Add(target.Name);

            if (target.ArmorThickness <= 0)
            {
                target.ArmorThickness = 0;
            }
        }      
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            if (this.targets.Count > 0)
            {
                sb.Append(" *Targets: ");
                sb.AppendLine(string.Join(", ", this.targets));
            }
            else
            {
                sb.AppendLine(" *Targets: None");
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void RepairVessel();
    }
}
