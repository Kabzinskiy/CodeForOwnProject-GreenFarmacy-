using DataBase;
using UnityEngine;

namespace Loaders
{
    public class TileLoader:ILoader
    {
        public void Load()
        {
            Memory.Tile = Resources.Load<Sprite>("Data/Sprites/Gizmos/Tile");
        }
    }
}
