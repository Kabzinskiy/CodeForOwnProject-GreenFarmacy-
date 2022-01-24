using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using UnityEngine;

namespace Loaders
{
    class BuildingPrefabLoader : ILoader
    {
        public void Load()
        {
            List<GameObject> buildPrefabs = Resources.LoadAll<GameObject>("Prefabs/BuildingObjects/Buildings").ToList();
            foreach (var prefab in buildPrefabs)
            {
                string[] parts = prefab.name.Split(new char[]{'_'});
                string type = parts.First();
                int lvl = Convert.ToInt32(parts.Last());
                switch (type)
                {
                    case "Dryer":
                        if (!Memory.BuildingPrefabs.ContainsKey(type))
                        {
                            Memory.BuildingPrefabs.Add(type, new Dictionary<int, GameObject>());
                        }
                        Memory.BuildingPrefabs[type].Add(lvl, prefab);
                        break;
                    case "TeaFactory":
                        if (!Memory.BuildingPrefabs.ContainsKey(type))
                        {
                            Memory.BuildingPrefabs.Add(type, new Dictionary<int, GameObject>());
                        }
                        Memory.BuildingPrefabs[type].Add(lvl, prefab);
                        break;
                    case "Hives":
                        if (!Memory.BuildingPrefabs.ContainsKey(type))
                        {
                            Memory.BuildingPrefabs.Add(type, new Dictionary<int, GameObject>());
                        }
                        Memory.BuildingPrefabs[type].Add(lvl, prefab);
                        break;
                    case "HoneyDriver":
                        if (!Memory.BuildingPrefabs.ContainsKey(type))
                        {
                            Memory.BuildingPrefabs.Add(type, new Dictionary<int, GameObject>());
                        }
                        Memory.BuildingPrefabs[type].Add(lvl, prefab);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
