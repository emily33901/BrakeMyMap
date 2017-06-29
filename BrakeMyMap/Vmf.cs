using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gameloop.Vdf;
using BrakeMyMap;

namespace BrakeMyMap
{
	// small wrapper for a vmf file
	// also the wrapper for the world object within the map since that is the most commonly used
	class Vmf
	{
		private VObject level;

		public Vmf(string mapname)
		{
			// read the file
			string fileString = Encoding.Default.GetString(File.ReadAllBytes(mapname));

			// enclose in an object so that we can parse it properly
			fileString = "level\r\n{\r\n" + fileString + "\r\n}\r\n";


			// peform the parsing or deserialisation
			var file = VdfConvert.Deserialize(fileString);

			// strip the top level object again leaving the default vmf
			level = file.Children().ElementAt(0).ToVObject();
		}

		public VObject World
		{
			get
			{
				return level["world"].ToVObject();
			}
		}

		// returns an array of all the solids in the map
		public Solid[] Solids
		{
			get
			{
				List<Solid> solids = new List<Solid>();

				foreach (var child in World.Children())
				{
					if (child.Key == "solid")
					{
						solids.Add(new Solid(child.ToVObject()));
					}
				}

				return solids.ToArray();
			}
		}

		public void Save(string savename)
		{
			// serialize back to a string
			string newLevel = VdfConvert.Serialize(level);

			// remove opening and closing curly braces as vmf does not use these
			string newVmf = newLevel.Substring(1, newLevel.Length - 4);

			// untab every line once to make thing look nicer
			newVmf = newVmf.Replace("\n\t", "\n");

			// write the new vmf output
			// TODO: we could do a compile here if we felt like it
			File.WriteAllText(savename, newVmf);
		}

	}
}
