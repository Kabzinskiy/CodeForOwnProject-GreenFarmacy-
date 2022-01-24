using System.Collections.Generic;
using System.Linq;
using DataBase;
using Language;

namespace Scripts
{
    public static class CurrentProperties
    {
        public static string CurrentBuildKey { get; set; } = "";
        public static List<string> StartBuildingKeys { get; set; } = new List<string>();
        public static bool CommonBuildMode { get; set; } = false;
        public static Languages lang { get; set; } = Languages.Rus;
        public static bool CanStayBuilding { get; set; } = true;
        public static int SellCount { get; set; } = 1;
        public static bool CanToMove { get; set; } = true;

        public static int GetBuildingCost(string langCode, int lvl)
        {
            int count = 1;
            
            foreach (var building in Memory.Player.Buildings.Where(x => x.Value.LangCode == langCode))
            {
                ++count;
            }

            return StartCost[langCode] * count * lvl;
        }


        private static Dictionary<string, int> StartCost = new Dictionary<string, int>
        {
            {"Dryer", 100},
            {"TeaFactory", 500},
            {"Hives", 1000},
            {"HoneyDriver", 2000},
            {"JamFactory", 8000},
            {"VitaminFactory", 10000}
        };

    }
}
