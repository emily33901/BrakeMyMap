using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gameloop.Vdf;
using BrakeMyMap;

namespace BrakeMyMap
{
	class TextureAxis
	{
		private float x;

		private float y;

		private float z;

		private float translation;

		private float totalScale;
		// TODO:

		public VValue Axis { get; set; }

		public float X
		{
			get { return x; }
			set
			{
				x = value;
				UpdateTree();
			}
		}

		public float Y
		{
			get { return y; }
			set
			{
				y = value;
				UpdateTree();
			}
		}

		public float Z
		{
			get { return z; }
			set
			{
				z = value;
				UpdateTree();
			}
		}

		public float Translation
		{
			get { return translation; }
			set
			{
				translation = value;
				UpdateTree();
			}
		}

		public float TotalScale
		{
			get { return totalScale; }
			set
			{
				totalScale = value;
				UpdateTree();
			}
		}

		public dynamic Dynamic { get { return Axis; } }

		public TextureAxis(VValue axis)
		{
			Axis = new VValue(axis);

			// break down the string into its parts

			// format
			// "[0 1 0 0] 0.25"

			string axisString = Axis.ToString();

			string[] delims = {"[", "] "};

			string[] parts = axisString.Split(delims, StringSplitOptions.RemoveEmptyEntries);

			string[] xyz = parts[0].Split(' ');

			x = float.Parse(xyz[0]);
			y = float.Parse(xyz[1]);
			z = float.Parse(xyz[2]);

			translation = float.Parse(xyz[3]);

			totalScale = float.Parse(parts[1]);


		}

		private void UpdateTree()
		{
			Axis.Value = string.Format("[{0} {1} {2} {3}] {4}", x, y, z, translation, totalScale);
		}

	}


}
