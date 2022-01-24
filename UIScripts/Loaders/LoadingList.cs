
using System.Collections.Generic;

namespace Loaders
{
    public static class LoadingList
    {
         
        public static  List<ILoader> loaders = null;

        static LoadingList()
        {
            loaders = new List<ILoader>();
            loaders.Add(new ProfileLoader());
            loaders.Add(new FlowersLoader());
            loaders.Add(new PhrasesLoader());
            loaders.Add(new TileLoader());
            loaders.Add(new BuildingPrefabLoader());
            loaders.Add(new LocationLoader());
            loaders.Add(new LocationPrefabLoader());
            loaders.Add(new ReceptsLoader());
            loaders.Add(new ProductSpriteLoader());

            loaders.Add(new BasicLoader());   //the last
        }
    }
}
