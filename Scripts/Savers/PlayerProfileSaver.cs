using System.Xml.Linq;
using DataBase;
using UnityEngine;


namespace Savers
{
    public static class PlayerProfileSaver
    {
        private static string resultPath { get; } = Application.persistentDataPath + "/Profile.xml";

        public static void Save()
        {
            var player = Memory.Player;
            XDocument document = new XDocument();
            XElement profileEl = new XElement("Profile");

            profileEl.Add(new XAttribute("CurrentEnergy", player.CurrentEnergy));
            profileEl.Add(new XAttribute("PlayerExperience", player.PlayerExperience));
            profileEl.Add(new XAttribute("Money", player.Money));

            foreach (var building in player.Buildings)
            {
                XElement xBuilding = new XElement("Building");
                xBuilding.Add(new XAttribute("LangCode", building.Value.LangCode));
                xBuilding.Add(new XAttribute("Lvl", building.Value.Lvl));
                xBuilding.Add(new XAttribute("x", building.Value.Position.x));
                xBuilding.Add(new XAttribute("y", building.Value.Position.y));
                profileEl.Add(xBuilding);
            }

            foreach (var item in player.OpenList)
            {
                XElement xItem = new XElement("OpenList");
                xItem.Add(new XAttribute("LangCode", item));
                profileEl.Add(xItem);
            }

            document.Add(profileEl);
            document.Save(resultPath);
        }
    }
}

