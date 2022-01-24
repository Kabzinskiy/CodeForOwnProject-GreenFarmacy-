using System.Collections.Generic;
using DataBase;

namespace Scripts
{
    public class Location
    {
        public string LangCode { get; set; }
        public int Lvl { get; set; }
        public int Energy { get; set; }
        public int Cost { get; set; }
        public List<string> Plants { get; set; }

        public string GetName()
        {
            string result = "";
            for (int i = 0; i < Plants.Count; ++i)
            {
                if (i == 0)
                {
                    result += Memory.Phrases[Plants[i]].GetValue();
                }
                else
                {
                    result += ",\n" + Memory.Phrases[Plants[i]].GetValue();
                }
                
            }
            return result;
        }

    }
}
