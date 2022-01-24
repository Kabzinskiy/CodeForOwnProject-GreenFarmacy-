using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Scripts;
using UnityEngine;

namespace Loaders
{
    public class LocationLoader : ILoader
    {
        public void Load()
        {
            var document = XDocument.Load(new StringReader(Resources.Load<TextAsset>("Data/Documents/LocationsData").text));
            foreach (var xLocation in document.Element("Locations")?.Elements("Location") ?? throw new ArgumentNullException())
            {
                List<string> plants = new List<string>();
                foreach (var xPlant in xLocation.Elements("Plant"))
                {
                    plants.Add(xPlant.Attribute("LangCode").Value);
                }
                DataBase.Memory.Locations.Add(new Location
                {
                    LangCode = xLocation.Attribute("LangCode")?.Value,
                    Lvl = Convert.ToInt32(xLocation.Attribute("Lvl")?.Value),
                    Energy = Convert.ToInt32(xLocation.Attribute("Energy")?.Value),
                    Cost = Convert.ToInt32(xLocation.Attribute("Cost")?.Value),
                    Plants = plants
                });
            }
        }
    }
}
