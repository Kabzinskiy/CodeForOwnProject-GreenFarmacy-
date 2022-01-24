using System;
using DataBase;
using Scripts;

namespace Language
{
    public enum Languages
    {
        Rus = 1,
        Eng = 2
    }
    public class Phrase
    {
        public string RusPhrase { get; set; }
        public string EngPhrase { get; set; }

        public string GetValue()
        {
            if (Memory.Player.English)
            {
                CurrentProperties.lang = Languages.Eng;
            }
            else
            {
                CurrentProperties.lang = Languages.Rus;
            }
            
            switch (CurrentProperties.lang)
            {
                case Languages.Rus:
                    return RusPhrase;
                case Languages.Eng:
                    return EngPhrase;
                default:
                    throw new ArgumentNullException();
            }
        }

    }
}
