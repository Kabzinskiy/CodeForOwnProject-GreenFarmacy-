using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using DataBase;
using Scripts;
using UnityEngine;

namespace Loaders
{
    public class ReceptsLoader : ILoader
    {
        public void Load()
        {
            var document = XDocument.Load(new StringReader(Resources.Load<TextAsset>("Data/Documents/Recepts").text));
            foreach (var xRecept in document.Element("Recepts")?.Elements("Recept") ?? throw new ArgumentNullException())
            {
                Dictionary<string, int> requirements = new Dictionary<string, int>();
                foreach (var requirement in xRecept.Elements("Requirement"))
                {
                    string prodLangCode = requirement.Attribute("LangCode")?.Value;
                    int prodCount = Convert.ToInt32(requirement.Attribute("Count")?.Value);
                    requirements.Add(prodLangCode, prodCount);   
                }
                Memory.Recepts.Add(new Recept
                {
                    LangCode = xRecept.Attribute("LangCode")?.Value,
                    Building = xRecept.Attribute("Building")?.Value,
                    Time = Convert.ToInt32(xRecept.Attribute("Time")?.Value),
                    Requirements = requirements
                });
            }
        }
    }
}
