using Pixelmap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK2toCK3TerrainConverter
{
    class CK3Province
    {
        public int ID { get; set; }
        public string CK3TerrainName { get; set; }
        public CK2Terrain CK2Terrain { get; set; }

        public Color Color { get; set; }
        public List<Pixel> InsideTerrainPixels { get; }

        public CK3Province()
        {
            InsideTerrainPixels = new List<Pixel>();
        }

        public CK3Province(CK3Province other)
        {
            ID = other.ID;
            CK3TerrainName = other.CK3TerrainName;
            CK2Terrain = other.CK2Terrain;
            Color = other.Color;
            InsideTerrainPixels = other.InsideTerrainPixels;
        }

        public string PrintTerrain() => $"{ID}={CK3TerrainName}";
    }
}
