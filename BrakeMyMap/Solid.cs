using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gameloop.Vdf;
using BrakeMyMap;

namespace BrakeMyMap
{
	class Solid : IAsDynamic
	{

		public List<Side> Sides { get; private set; }

		private VObject solid;

		public dynamic Dynamic { get { return solid; } }

		public Solid(VObject sol)
		{
			solid = sol;
			Sides = new List<Side>();

			// get the sides and add them here

			foreach (var child in solid.Children())
			{
				if (child.Key == "side")
				{
					// this is a side add it
					Sides.Add(new Side(child.ToVObject()));
				}
			}
		}

		public Side TopSide
		{
			get
			{
				Side bestSide = Sides[0];

				foreach (var side in Sides)
				{
					if (side.Plane.IsHorizontal())
					{
						if (side.Plane.BottomLeft[2] > bestSide.Plane.BottomLeft[2])
						{
							// change the best side
							bestSide = side;
						}
					}
				}

				return bestSide;
			}
		}
	}
}
