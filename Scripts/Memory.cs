using System.Collections.Generic;
using Language;
using Plants;
using Profile;
using Scripts;
using UnityEngine;

namespace DataBase
{
    public static class Memory
    {
        public static PlayerProfiles Player { get; set; } = new PlayerProfiles();
        public static List<Recept> Recepts { get; set; } = new List<Recept>();
        public static Dictionary<string, Phrase> Phrases { get; set; } = new Dictionary<string, Phrase>();
        public static Dictionary<string, PlantsSet> PlantsSprites { get; set; } = new Dictionary<string, PlantsSet>();
        public static List<Plants.Plant> Plants { get; set; } = new List<Plants.Plant>();

        public static Sprite Tile = Resources.Load<Sprite>("Data/Sprites/Gizmos/Tile");    //{ get; set; }  test
        public static Dictionary<string, Dictionary<int, GameObject>> BuildingPrefabs { get; set; } =
            new Dictionary<string, Dictionary<int, GameObject>>();  //string is LangCode, int is Lvl
        public static Dictionary<long, int> PlayerLevels { get; set; } = new Dictionary<long, int>();//long is experience, int is level
        public static List<Location> Locations { get; set; } = new List<Location>();

        public static Dictionary<string, Sprite> ProductSprites = new Dictionary<string, Sprite>();

        public static Dictionary<string, GameObject> LocationPrefabs { get; set; } =   //string is LangCode, GameObject is location
            new Dictionary<string, GameObject>();
    }
}
