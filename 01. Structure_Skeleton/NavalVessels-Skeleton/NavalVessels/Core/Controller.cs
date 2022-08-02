using NavalVessels.Core.Contracts;
using NavalVessels.Models.Contracts;
using NavalVessels.Models.Entities;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    internal class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public VesselRepository Vessels
        {
            get; set;
        }

        public List<ICaptain> Captains
        {
            get; set;
        }

        //check again later
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            string resultMessage = "";
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = vessels.FindByName(selectedVesselName);
            if (!this.captains.Contains(captain))
            {
                resultMessage = $"Captain {selectedCaptainName} could not be found.";
            }
            else if (vessel == null)
            {
                resultMessage = $"Vessel {selectedVesselName} could not be found.";
            }
            else if (vessel.Captain != null)
            {
                resultMessage = $"Vessel {selectedVesselName} is already occupied.";
            }
            else
            {
                vessel.Captain = captain;
                captain.AddVessel(vessel);
                resultMessage = $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
            }
            return resultMessage;
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            string resultMessage = "";
            var attackingVessel = vessels.FindByName(attackingVesselName);
            var defendingVessel = vessels.FindByName(defendingVesselName);
            if (attackingVessel == null || defendingVessel == null)
            {
                if (defendingVessel == null)
                {
                    resultMessage = $"Vessel {defendingVesselName} could not be found.";
                }
                if (attackingVessel == null)
                {
                    resultMessage = $"Vessel {attackingVesselName} could not be found.";
                }
            }
            else
            {
                if (attackingVessel.ArmorThickness == 0 || defendingVessel.ArmorThickness == 0)
                {
                    if (defendingVessel.ArmorThickness == 0)
                    {
                        resultMessage = $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
                    }
                    if (attackingVessel.ArmorThickness == 0)
                    {
                        resultMessage = $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
                    }
                }
                else 
                {
                    attackingVessel.Attack(defendingVessel);
                    attackingVessel.Captain.IncreaseCombatExperience();
                    defendingVessel.Captain.IncreaseCombatExperience();
                    resultMessage = $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName}" +
                        $" - current armor thickness: {defendingVessel.ArmorThickness}";
                }
            }
            return resultMessage;
        }

        public string CaptainReport(string captainFullName)
        {
            string resultMessage = "";
            Captain captain = new Captain(captainFullName);
            if (captains.Contains(captain))
            {
                resultMessage = captain.Report();       
            }
            return resultMessage;
        }

        public string HireCaptain(string fullName)
        {
            Captain captain = new Captain(fullName);
            string resultMessage;
            if (captains.Contains(captain))
            {
                resultMessage = $"Captain {fullName} is already hired.";
            }
            else
            {
                resultMessage = $"Captain {fullName} is hired.";
                captains.Add(captain);
            }
            return resultMessage;
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            string resultMessage = "";
            IVessel vessel = null;
            IVessel vesselInRepo = vessels.FindByName(name);
            if (vesselInRepo != null)
            {
                resultMessage = $"{vesselType} vessel {name} is already manufactured.";
            }
            switch (vesselType)
            {
                case "Battleship":
                    {
                        vessel = new Battleship(name, mainWeaponCaliber, speed);
                        break;
                    }
                case "Submarine":
                    {
                        vessel = new Submarine(name, mainWeaponCaliber, speed);
                        break;
                    }
                default:
                    {
                        resultMessage = "Invalid vessel type.";
                        break;
                    }
            }
            if (vessel != null)
            {
                resultMessage = $"{vesselType} {name} is manufactured with the main weapon caliber of " +
                    $"{mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
                vessels.Add(vessel);
            }
           
            return resultMessage;
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            string resultMessage = "";
            if (vessel != null)
            {
                vessel.RepairVessel();
                resultMessage = $"Vessel {vesselName} was repaired.";
            }
            else 
            {
                resultMessage = $"Vessel {vesselName} could not be found.";
            }
            return resultMessage;
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            string resultMessage = "";
            if (vessel != null)
            {
                if (vessel is Submarine)
                {
                    ((Submarine)vessel).ToggleSubmergeMode();
                    resultMessage = $"Submarine {vesselName} toggled submerge mode.";
                }
                if (vessel is Battleship)
                {
                    ((Battleship)vessel).ToggleSonarMode();
                    resultMessage = $"Battleship {vesselName} toggled sonar mode.";
                }
            }
            else
            {
                resultMessage = $"Vessel {vesselName} could not be found.";
            }
            return resultMessage;
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            return vessel.ToString();
        }
    }
}
