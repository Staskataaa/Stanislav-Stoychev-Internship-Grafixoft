using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models.Entities
{
    internal class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
            SubmergeMode = false;
        }
        public bool SubmergeMode
        {
            get { return submergeMode; }
            set { submergeMode = value; }
        }
        
        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                this.SubmergeMode = true;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
                this.SubmergeMode = false;
            }
        }

        public override void RepairVessel()
        {
            ArmorThickness = 200;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());

            string mode = "";

            if (this.SubmergeMode == true)
            {
                mode = "ON";
            }
            else
            {
                mode = "OFF";
            }
            stringBuilder.AppendLine($" *Submerge mode: {mode}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
