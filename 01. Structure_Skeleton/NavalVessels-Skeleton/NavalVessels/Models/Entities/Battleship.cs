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
        }

        private bool _sonarMode = false;

        public bool SonarMode
        {
            get { return _sonarMode; }
            set { _sonarMode = value; }
        }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if (SonarMode == true)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 300)
            {
                ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());

            if (SonarMode == false)
            {
                stringBuilder.AppendLine($" *Sonar mode: OFF");
            }
            if (SonarMode == true)
            {
                stringBuilder.AppendLine($" *Sonar mode: ");
            }
            return stringBuilder.ToString();
        }
    }
}
