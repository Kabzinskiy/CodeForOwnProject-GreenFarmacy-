using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using DataBase;
using Profile;
using UnityEngine;

namespace Loaders
{
    public class ProfileLoader : ILoader
    {
        public void Load()
        {
            XElement xProfile = null;
            
            if (File.Exists(Application.persistentDataPath + "/Profile.xml"))
            {
                xProfile = XDocument.Load(Application.persistentDataPath + "/Profile.xml").Element("Profile");
            }
            else
            {
                xProfile = XDocument.Load(new StringReader(Resources.Load<TextAsset>("Data/Documents/Profile").text)).Element("Profile");
            }
            
            var profile = new PlayerProfiles();
            profile.Money = (long)Convert.ToInt64(xProfile?.Attribute("Money")?.Value);
            profile.CurrentEnergy = Convert.ToInt32(xProfile?.Attribute("CurrentEnergy")?.Value);
            profile.PlayerExperience = Convert.ToInt32(xProfile?.Attribute("PlayerExperience")?.Value);
            profile.Buildings = new Dictionary<string, Building.Building>();
            foreach (var xBuilding in xProfile?.Elements("Building") ?? throw new ArgumentNullException())
            {
                profile.Buildings.Add(Guid.NewGuid().ToString(), new Building.Building
                {
                     LangCode = xBuilding.Attribute("LangCode")?.Value,
                     Lvl = Convert.ToInt32(xBuilding.Attribute("Lvl")?.Value),
                     Position = new Vector3(float.Parse(xBuilding.Attribute("x")?.Value), float.Parse(xBuilding.Attribute("y")?.Value), 0f)
                });
            }
            foreach (var xOpen in xProfile?.Elements("OpenList") ?? throw new ArgumentNullException())
            {
                profile.OpenList.Add(xOpen.Attribute("LangCode")?.Value);
            }
            Memory.Player = profile;
        }
    }
}
