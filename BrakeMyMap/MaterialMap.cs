using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrakeMyMap
{
	class MaterialMap
	{

		static Random r = new Random();

		static public string[] BlackCleanFloorTextures =
		{
			"METAL/BLACK_FLOOR_METAL_001C",
			"METAL/BLACK_FLOOR_METAL_002C",
			"METAL/BLACK_FLOOR_METAL_002B",
		};

		static public string[] BlackDirtyFloorTextures =
		{
			"METAL/BLACK_CEILING_METAL_001A",
			"METAL/BLACK_WALL_METAL_005A",
			"METAL/BLACK_WALL_METAL_005A_TOP",
			"METAL/BLACK_WALL_METAL_005A_VERTEX",
		};

		static public string[] BlackCleanWallTextures =
		{
			"METAL/BLACK_WALL_METAL_002C",
			"METAL/BLACK_WALL_METAL_002B"
		};

		static public string[] BlackDirtyWallTextures =
		{
			"METAL/UNDERGROUND_BLACK_TILE001B",
			"METAL/BLACK_WALL_METAL_002F",
			"METAL/BLACK_WALL_METAL_004C",
			"METAL/BLACK_WALL_METAL_004A",
			"METAL/BLACK_WALL_METAL_004B",
			"METAL/BLACK_WALL_METAL_005C",
			"METAL/BLACK_WALL_METAL_005C_TOP",
			"METAL/BLACK_WALL_METAL_005D",
		};

		static public string[] WhiteCleanFloorTextures =
		{
			"TILE/WHITE_FLOOR_TILE002A",
		};

		static public string[] WhiteDirtyFloorTextures =
		{
			"TILE/WHITE_FLOOR_TILE004D",
			"TILE/WHITE_FLOOR_TILE004D_VERTEX",
			"TILE/WHITE_FLOOR_TILE004E",
		};


		static public string ReplacementMaterial(string name)
		{
			if(BlackCleanFloorTextures.Contains(name))
			{
				return BlackDirtyFloorTextures[r.Next(BlackDirtyFloorTextures.Count())];
			}

			if (BlackCleanWallTextures.Contains(name))
			{
				return BlackDirtyWallTextures[r.Next(BlackDirtyWallTextures.Count())];
			}

			if (WhiteCleanFloorTextures.Contains(name))
			{
				return WhiteDirtyFloorTextures[r.Next(WhiteDirtyFloorTextures.Count())];
			}
			
			// TODO: WHITE WALL TEXTURES

			return name;
		}

	}
}
