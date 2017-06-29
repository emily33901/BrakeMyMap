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

			var r = new Random();
		
			foreach (var solid in map.Solids)
			{
				// update the materials for each side
				foreach (var side in solid.Sides)
				{
					side.Material = MaterialMap.ReplacementMaterial(side.Material);
					if (r.Next(0, 5) == 1)
					{
						// rotate this texture
						if (side.Plane.GetXSize() != 0.0f)
						{
							side.UAxis.Y = -side.UAxis.X;
						}

						if (side.Plane.GetYSize() != 0.0f)
						{
							side.UAxis.X = -side.UAxis.Y;
						}

						if (side.Plane.GetZSize() != 0.0f)
						{
							side.UAxis.Z = -side.UAxis.Z;
						}
						side.Rotation = 90;
					}
				}
			}

			foreach (var entity in map.Entities)
			{
				if (entity.ClassName == "func_instance" && entity.Dynamic.file.ToString().Contains("dropper"))
				{
					Console.WriteLine("{0}", entity.Dynamic);
				}
			}

			Console.WriteLine("Writing new vmf...");

			map.Save("../../maps/output.vmf");

			Console.WriteLine("Done!");
			Console.Read();
		}
	}
}
