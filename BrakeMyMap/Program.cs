using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValveKeyValue;
using Gameloop.Vdf;
using System.IO;

namespace BrakeMyMap
{
	class Program
	{

		static VObject ToVObject(VToken v)
		{
			return (VObject)v;
		}

		static VObject ToVObject(VProperty v)
		{
			return (VObject)v.Value;
		}

		static VProperty ToVProperty(VObject v)
		{
			return (VProperty)v.Parent;
		}

		static VProperty ToVProperty(VToken v)
		{
			return (VProperty)v;
		}

		static VValue ToVValue(VToken v)
		{
			return (VValue)v;
		}

		static void Main(string[] args)
		{
			string fileString = Encoding.Default.GetString(File.ReadAllBytes("hard_level.vmf"));

			fileString = "level\r\n{\r\n" + fileString + "\r\n}\r\n";

			var file = VdfConvert.Deserialize(fileString);

			VObject level = ToVObject(file.Children().ElementAt(0));

			VObject world = ToVObject(level["world"]);
			
			foreach(var worldProp in world.Children())
			{
				if (worldProp.Key != "solid")
					continue;

				var solid = ToVObject(worldProp);

				Solid s = new Solid();

				foreach(var solidProp in solid.Children())
				{
					if(solidProp.Key != "side")
					{
						continue;
					}

					var side = ToVObject(solidProp);

					var plane = ToVValue(side["plane"]);

					string planeString = plane.ToString();

					Plane p = new Plane(planeString);

					string material = ToVValue(side["material"]).ToString();
					string uaxis = ToVValue(side["uaxis"]).ToString();
					string vaxis = ToVValue(side["vaxis"]).ToString();

					s.Sides.Add(new Side(p, material, new TextureAxis(uaxis), new TextureAxis(vaxis), 0, 0, 0));
				}
				
				string replcementMaterial = MaterialMap.ReplacementMaterial(s.TopSide().Material);

				// find the topside and change the model in the tree
				foreach(var solidProp in solid.Children())
				{
					if (solidProp.Key != "side")
					{
						continue;
					}

					var side = ToVObject(solidProp);


					var plane = ToVValue(side["plane"]);

					string planeString = plane.ToString();

					Plane p = new Plane(planeString);

					Plane topPlane = s.TopSide().Plane;


					if (p == topPlane)
					{
						ToVValue(side["material"]).Value = replcementMaterial;
					}

					if(p.IsHorizontal() == false)
					{
						ToVValue(side["material"]).Value = MaterialMap.ReplacementMaterial(side["material"].ToString());

					}
				}

			}

			Console.WriteLine("Writing new vmf...");

			string newLevel = VdfConvert.Serialize(level);

			string newVmf = newLevel.Substring(1, newLevel.Length - 4);

			File.WriteAllText("test_brush_brake.vmf", newVmf);

			Console.WriteLine("Done!");
			Console.Read();
		}
	}
}
