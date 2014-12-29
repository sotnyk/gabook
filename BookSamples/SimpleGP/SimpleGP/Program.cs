using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGP
{
	class Program
	{
		static void Main(string[] args)
		{
			GPWorld world = new GPWorld();
			for (int g = 0; world.Generation[0].Genome != GPWorld.SecretPattern; ++g)
			{
				WriteWorldState(g, world);
				world.Next(true);
			}
			WriteWorldState("last", world);
			Console.WriteLine("The solution found!");
			Console.ReadLine();
		}

        private static void WriteWorldState(object generation, GPWorld world)
        {
            Console.WriteLine("Best individual {0}:", generation);
            Console.WriteLine("  Genome=" + world.Generation[0].Genome);
			Console.WriteLine("  Length=" + world.Generation[0].Genome.Length);
			Console.WriteLine("  Fitness=" + world.Generation[0].Fitness);
			Console.WriteLine("---------------------------------------");
		}
	}
}
