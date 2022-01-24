using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace Loaders
{
    public class FlowersLoader : ILoader
    {
        public void Load()
        {
            var document = XDocument.Load(new StringReader(Resources.Load<TextAsset>("Data/Documents/Plants").text));
            foreach (var xFlower in document.Element("Plants")?.Elements("Flower") ?? throw new ArgumentNullException())
            {
                DataBase.Memory.Plants.Add( new Plants.Plant
                {
                    LangCode = xFlower.Attribute("LangCode")?.Value,
                    Points = Convert.ToInt32(xFlower.Attribute("Points")?.Value),
                    PartsQuant = Convert.ToInt32(xFlower.Attribute("Parts")?.Value) 
                });
            }
        }
    }
}
