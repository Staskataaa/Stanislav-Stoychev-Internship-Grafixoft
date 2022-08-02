namespace NavalVessels
{
    using Core;
    using Core.Contracts;
    using NavalVessels.Models.Entities;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            /*Engine engine = new Engine();
            engine.Run();*/


            Battleship battleship = new Battleship("BattleShip", 35, 15);
            Captain captain = new Captain("Ivan");
            Captain captain2 = new Captain("Georgi");
            captain.AddVessel(battleship);
            Submarine submarine = new Submarine("Submarine", 25, 20);
            captain2.AddVessel(submarine);
            submarine.ToggleSubmergeMode();
            submarine.Attack(battleship);
            battleship.ToggleSonarMode();
            battleship.ToggleSonarMode();
            submarine.ToggleSubmergeMode();
            battleship.Attack(submarine);
            submarine.RepairVessel();
            battleship.RepairVessel();
            Console.WriteLine(submarine.ToString());
            battleship.ToggleSonarMode();
            Console.WriteLine(battleship.ToString());
            Console.WriteLine(captain.Report());
            captain.AddVessel(battleship);
            Console.ReadLine();
        }
    }
}