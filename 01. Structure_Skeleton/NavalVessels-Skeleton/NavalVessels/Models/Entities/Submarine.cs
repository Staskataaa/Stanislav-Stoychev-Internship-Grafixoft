using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models.Entities
{
    internal class Submarine : Vessel, ISubmarine
    {
        private bool _submergeMode = false;

        public bool SubmergeMode
        {
            get { return _submergeMode; }
            set  { _submergeMode = value; }
        }
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {

        }
        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode == true)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else if(SubmergeMode == false)
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if(ArmorThickness < 200)
            {
                ArmorThickness = 200;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());

            if (SubmergeMode == false)
            {
                stringBuilder.AppendLine($" *Sonar mode: OFF");
            }
            if (SubmergeMode == true)
            {
                stringBuilder.AppendLine($" *Sonar mode: ");
            }

            return stringBuilder.ToString();
        }
    }
}
