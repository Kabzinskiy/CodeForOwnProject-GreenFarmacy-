using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataBase;
using Language;
using UnityEngine;

namespace Loaders
{
    public class PhrasesLoader: ILoader
    {
        public void Load()
        {
            var rusDocument = XDocument.Load(new StringReader(Resources.Load<TextAsset>("Data/Documents/Languages/Rus_lang").text));
            var engDocument = XDocument.Load(new StringReader(Resources.Load<TextAsset>("Data/Documents/Languages/Eng_lang").text));
            foreach (var xRusPhrase in rusDocument.Element("Russian")?.Elements() ?? throw new ArgumentNullException())
            {
                Memory.Phrases.Add(xRusPhrase.Attribute("LangCode").Value,
                    new Phrase {RusPhrase = xRusPhrase.Attribute("Value").Value});
            }

            foreach (var xEngPhrase in engDocument.Element("English")?.Elements() ?? throw new ArgumentNullException())
            {
                Memory.Phrases[xEngPhrase.Attribute("LangCode").Value].EngPhrase = xEngPhrase.Attribute("Value")?.Value;
            }
        }
    }
}
