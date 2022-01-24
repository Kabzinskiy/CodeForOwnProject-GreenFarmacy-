using System.Collections.Generic;
using System.Linq;
using DataBase;
using UnityEngine;

namespace Loaders
{
    public class ProductSpriteLoader : ILoader
    {
        public void Load()
        {
            List<Sprite> sprites = Resources.LoadAll<Sprite>("Data/Sprites/Products").ToList();
            foreach (var sprite in sprites)
            {
                Memory.ProductSprites.Add(sprite.name, sprite);
            }
        }
    }
}
