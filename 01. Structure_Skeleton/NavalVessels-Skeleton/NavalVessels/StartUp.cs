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
            Engine engine = new Engine();
            engine.Run();
          
        }
    }
}