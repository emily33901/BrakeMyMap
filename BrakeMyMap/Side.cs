using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gameloop.Vdf;
using BrakeMyMap;

namespace BrakeMyMap
{
	class Side
	{
		private VObject side;


		private Plane plane;
		private string material;
		private TextureAxis uaxis;
		private TextureAxis vaxis;
		private float rotation;
		private int lightmapscale;
		private int smoothingGroups;

		public Plane Plane
		{
			get { return plane; }
			private set { plane = value;
				UpdateTree();
			}
		}

		public string Material
		{
			get { return material; }
			set { material = value; UpdateTree(); }
		}

		public TextureAxis UAxis
		{
			get { return uaxis; }
			private set { uaxis = value; UpdateTree(); }
		}

		public TextureAxis VAxis
		{
			get { return vaxis; }
			private set { vaxis = value; UpdateTree(); }
		}

		public float Rotation
		{
			get { return rotation; }
			set { rotation = value; UpdateTree(); }
		}

		public int LightMapScale
		{
			get { return lightmapscale; }
			set { lightmapscale = value; UpdateTree(); }
		}

		public int SmoothingGroups
		{
			get { return smoothingGroups; }
			set { smoothingGroups = value; UpdateTree(); }
		}

		public Side(VObject side)
		{
			this.side = side;
			plane = new Plane(side["plane"].ToVValue());

			material = side["material"].ToString(); ;

			uaxis = new TextureAxis(side["uaxis"].ToVValue());
			vaxis = new TextureAxis(side["vaxis"].ToVValue());

			rotation = float.Parse(side["rotation"].ToString());
			lightmapscale = int.Parse(side["lightmapscale"].ToString());
			smoothingGroups = int.Parse(side["smoothing_groups"].ToString());
		}

		private void UpdateTree()
		{
			// plane updates itself
			side["material"].ToVValue().Value = material;

			// uaxis, vaxis updates itself

			side["rotation"].ToVValue().Value = rotation;
			side["lightmapscale"].ToVValue().Value = lightmapscale;
			side["smoothing_groups"].ToVValue().Value = smoothingGroups;
		}


	}
}
