using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gameloop.Vdf;
using BrakeMyMap;

namespace BrakeMyMap
{
	class Entity : IAsDynamic
	{
		public VObject entity { get; set; }
		private string classname;
		private int spawnFlags;
		private List<Connection> connections;
		private float[] origin;

		public string ClassName
		{
			get { return classname; }
			set
			{
				classname = value;
				UpdateTree();
			}
		}

		bool HasSpawnFlags { get; set; }

		public int SpawnFlags
		{
			get { return spawnFlags; }
			set
			{
				spawnFlags = value;
				UpdateTree();
			}
		}

		public List<Connection> Connections
		{
			get { return connections; }
			set
			{
				connections = value;
				UpdateTree();
			}
		}

		bool IsPointEntity { get; set; }

		public float[] Origin
		{
			get { return origin; }
			set
			{
				origin = value;
				UpdateTree();
			}
		}

		public dynamic Dynamic { get { return entity; } }

		public Solid Solid { get; set; }

		public Entity(VObject ent)
		{
			connections = new List<Connection>();
			entity = ent;

			classname = ent["classname"].ToString();

			if (ent.ContainsKey("spawnflags"))
			{
				spawnFlags = int.Parse(ent["spawnflags"].ToString());
				HasSpawnFlags = true;
			}


			if (ent.ContainsKey("origin"))
			{
				origin = Array.ConvertAll(ent["origin"].ToString().Split(' '), float.Parse);
				IsPointEntity = true;
			}
			else if (ent.ContainsKey("solid"))
			{
				Solid = new Solid(ent["solid"].ToVObject());
				IsPointEntity = false;
			}

			if (ent.ContainsKey("connections"))
			{
				foreach (var child in ent["connections"].ToVObject().Children())
				{
					connections.Add(new Connection(child));
				}
			}

		}

		private void UpdateTree()
		{
			// TODO:
			entity["classname"].ToVValue().Value = classname;

			if (HasSpawnFlags)
				entity["spawnflags"].ToVValue().Value = spawnFlags;

			if (IsPointEntity)
			{
				entity["origin"].ToVValue().Value = string.Format("{0} {1} {2}", origin[0], origin[1], origin[2]);
			}
			// solid is handled by itself

			// conections are handled by themselves
		}
	}
}
