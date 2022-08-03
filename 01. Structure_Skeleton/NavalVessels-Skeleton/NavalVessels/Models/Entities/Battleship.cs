using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models.Entities
{
    internal class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {           
            SonarMode = false;
        }

        private bool sonarMode;

        public bool SonarMode
        {
            get { return sonarMode; }
            set { sonarMode = value; }
        }

        public void ToggleSonarMode()
        {
            if (this.sonarMode == false)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                this.SonarMode = true;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                this.SonarMode = false;
            }
        }

        public override void RepairVessel()
        {
                ArmorThickness = 300;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            string mode = "";
            if (SonarMode == false)
            {
                mode = "OFF";
            }
            else if (SonarMode == true)
            {
                mode = "ON";
            }
            stringBuilder.AppendLine($" *Sonar mode: {mode}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
