using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrakeMyMap
{
	class Side
	{

		public Plane Plane { get; set; }
		public string Material { get; set; }

		public TextureAxis UAxis { get; set; }
		public TextureAxis VAxis { get; set; }

		public float Rotation { get; set; }

		public int LightMapScale { get; set; }

		public int SmoothingGroups { get; set; }

		public Side(Plane p, string mat, TextureAxis uaxis, TextureAxis vaxis, float rotation, int lightMapScale, int smoothingGroups)
		{
			Plane = p;
			Material = mat;
			UAxis = uaxis;
			VAxis = vaxis;
			Rotation = rotation;
			LightMapScale = lightMapScale;
			SmoothingGroups = smoothingGroups;
		}
	}
}
