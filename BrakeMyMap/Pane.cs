using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrakeMyMap
{
	class Plane
	{
		public float[] BottomLeft { get; set; }
		public float[] TopLeft { get; set; }
		public float[] TopRight { get; set; }

		public Plane(string s)
		{
			string[] delims = { "(", ") ", ")" };

			string[] points = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

			// each one of the points contains a 3 floats seperated by a space - seperate these

			BottomLeft = Array.ConvertAll(points[0].Split(' '), Single.Parse);
			TopLeft = Array.ConvertAll(points[1].Split(' '), Single.Parse);
			TopRight = Array.ConvertAll(points[2].Split(' '), Single.Parse);
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
