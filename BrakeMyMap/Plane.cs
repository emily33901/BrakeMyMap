using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gameloop.Vdf;

namespace BrakeMyMap
{
	class Plane
	{
		private VValue TreeValue;
		private float[] topLeft;
		private float[] topRight;
		private float[] bottomLeft;


		public float[] BottomLeft
		{
			get { return this.bottomLeft; }
			set
			{
				this.bottomLeft = value;
				UpdateTree();
			}
		}

		public float[] TopLeft
		{
			get { return topLeft; }
			set { topLeft = value;
				UpdateTree();
			}
		}

		public float[] TopRight
		{
			get { return topRight; }
			set { topRight = value;
				UpdateTree();
			}
		}

		public Plane(VValue value)
		{
			// get the reference
			TreeValue = new VValue(value);

			string s = value.ToString();

			string[] delims = { "(", ") ", ")" };

			string[] points = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

			// each one of the points contains a 3 floats seperated by a space - seperate these

			bottomLeft = Array.ConvertAll(points[0].Split(' '), float.Parse);
			topLeft = Array.ConvertAll(points[1].Split(' '), float.Parse);
			topRight = Array.ConvertAll(points[2].Split(' '), float.Parse);
		}

		void UpdateTree()
		{
			// TODO:
			TreeValue.Value = string.Format("({0} {1} {2}) ({3} {4} {5}) ({6} {7} {8})", BottomLeft[0], BottomLeft[1], BottomLeft[2],
				TopLeft[0], TopLeft[1], TopLeft[2],
				TopRight[0], TopRight[1], TopRight[2]);
		}

		public float GetXSize()
		{
			return Math.Abs((BottomLeft[0] - TopLeft[0]) - (TopLeft[0] - TopRight[0]));
		}

		public float GetYSize()
		{
			return Math.Abs((BottomLeft[1] - TopLeft[1]) - (TopLeft[1] - TopRight[1]));
		}

		public float GetZSize()
		{
			return Math.Abs((BottomLeft[2] - TopLeft[2]) - (TopLeft[2] - TopRight[2]));
		}

		public bool IsHorizontal()
		{
			return GetZSize() == 0.0f;
		}

		public static bool operator ==(Plane a, Plane b)
		{
			return
				a.BottomLeft[0] == b.BottomLeft[0] &&
				a.BottomLeft[1] == b.BottomLeft[1] &&
				a.BottomLeft[2] == b.BottomLeft[2] &&
				a.TopLeft[0] == b.TopLeft[0] &&
				a.TopLeft[1] == b.TopLeft[1] &&
				a.TopLeft[2] == b.TopLeft[2] &&
				a.TopRight[0] == b.TopRight[0] &&
				a.TopRight[1] == b.TopRight[1] &&
				a.TopRight[2] == b.TopRight[2];
		}

		public static bool operator !=(Plane a, Plane b)
		{
			return !(a == b);
		}

	}
}
