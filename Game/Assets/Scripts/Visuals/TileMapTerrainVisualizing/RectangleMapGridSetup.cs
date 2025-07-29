using TDS.Maps;
using UnityEngine;

namespace TDS.Entities
{
    public class RectangleMapGridSetup
    {
        public void Setup(IMap map, Grid grid)
        {
            if (map is RectangleMap map1)
            {
                grid.transform.position = new Vector3(
                    map1.TileCount.x% 2== 0? 0:map1.TileSize.x/2,
                    map1.TileCount.y% 2== 0? 0:map1.TileSize.y/2);
                grid.cellSize = map1.TileSize;
            }
        }
    }
}