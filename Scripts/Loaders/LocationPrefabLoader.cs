using System.Collections.Generic;
using System.Linq;
using DataBase;
using UnityEngine;

namespace Loaders
{
    public class LocationPrefabLoader : ILoader
    {
        public void Load()
        {
            List<GameObject> locationPrefabs = Resources.LoadAll<GameObject>("Prefabs/Locations").ToList();
            foreach (var xLocation in locationPrefabs)
            {
                Memory.LocationPrefabs.Add(xLocation.name, xLocation);
            }

        }
    }
}
