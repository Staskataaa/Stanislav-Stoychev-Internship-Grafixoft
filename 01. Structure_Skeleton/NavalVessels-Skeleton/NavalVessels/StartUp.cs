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
            captain.AddVessel(battleship);
          
        }
    }
}