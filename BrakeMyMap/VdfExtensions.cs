using Gameloop.Vdf;

namespace BrakeMyMap
{
	static class VdfExtensions
	{
		public static VObject ToVObject(this VToken v)
		{
			return (VObject)v;
		}

		public static VObject ToVObject(this VProperty v)
		{
			return (VObject)v.Value;
		}

		public static VProperty ToVProperty(this VObject v)
		{
			return (VProperty)v.Parent;
		}

		public static VProperty ToVProperty(this VToken v)
		{
			return (VProperty)v;
		}

		public static VValue ToVValue(this VToken v)
		{
			return (VValue)v;
		}
	}
}
