using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValveKeyValue;
using Gameloop.Vdf;
using System.IO;
using BrakeMyMap;

namespace BrakeMyMap
{

	class Program
	{
		static void Main(string[] args)
		{
			Vmf map = new Vmf("../../maps/hard_level.vmf");
			
			foreach(var solid in map.Solids)
			{
				// update the materials
				solid.TopSide.Material = MaterialMap.ReplacementMaterial(solid.TopSide.Material);

			}

			Console.WriteLine("Writing new vmf...");

			map.Save("../../maps/output.vmf");

			Console.WriteLine("Done!");
			Console.Read();
		}
	}
}
