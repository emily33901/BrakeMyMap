using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrakeMyMap
{
	class Solid
	{

		public List<Side> Sides { get; set; }

		public Solid()
		{
			Sides = new List<Side>();
		}


		public Side TopSide()
		{
			Side bestSide = Sides[0];

			foreach(var side in Sides)
			{
				if(side.Plane.IsHorizontal())
				{
					if(side.Plane.BottomLeft[2] > bestSide.Plane.BottomLeft[2])
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
