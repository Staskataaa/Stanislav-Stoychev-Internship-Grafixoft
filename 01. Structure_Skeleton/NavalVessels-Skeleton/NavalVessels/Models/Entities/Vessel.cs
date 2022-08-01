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
        private string _name;
        private ICaptain _captain;
        private double _armorThickness;
        private double _mainWeaponCaliber;
        private double _speed;
        private ICollection<string> _targets = new List<string>();

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public ICaptain Captain
        {
            get
            {
                if (_captain == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainName);
                }
                return _captain;
            }
            set
            {
                _captain = value;
            }
        }

        public double ArmorThickness
        {
            get { return _armorThickness; }
            set { _armorThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get { return _mainWeaponCaliber; }
            set { _mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return _speed; }
            set { _speed = value;  }
        }

        public ICollection<string> Targets
        {
            get { return _targets; }
            set { _targets = value; }
        }

        private bool IsThicknessOverZero(double mainWeaponCaliber, double thickness)
        {
            bool result = false;
            if (thickness - mainWeaponCaliber > 0)
            {
                result = true;
            }
            return result;
        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            if (IsThicknessOverZero(MainWeaponCaliber, target.ArmorThickness))
            {
                target.ArmorThickness -= MainWeaponCaliber;
            }
            else if(!IsThicknessOverZero(MainWeaponCaliber, target.ArmorThickness)) 
            {
                target.ArmorThickness = 0;
            }
            Targets.Add(target.Name);
        }

      
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            _name = name;
            _mainWeaponCaliber = mainWeaponCaliber;
            _speed = speed;
            _armorThickness = armorThickness;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"- {Name}");
            stringBuilder.AppendLine($" *Type: {GetType().Name}");
            stringBuilder.AppendLine($" *Armor thickness: {ArmorThickness}");
            stringBuilder.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            stringBuilder.AppendLine($" *Speed: {Speed} knots");
            stringBuilder.Append(" *Targets: ");

            if (Targets == null)
            {
                stringBuilder.Append("None");
            }
            else if (Targets.Count() != 0)
            {
                string toBeAppended = "";
                for (int i = 0; i < Targets.Count(); i++)
                {
                    toBeAppended += Targets.ElementAt(i) + " ";

                }
                stringBuilder.Append(toBeAppended.TrimEnd());
            }

            return stringBuilder.ToString();
        }

        public virtual void RepairVessel()
        {
            throw new NotImplementedException();
        }
    }
}
