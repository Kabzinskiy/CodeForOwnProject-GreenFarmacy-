using System.Collections.Generic;

namespace Scripts
{
    public class Recept
    {
        public string LangCode { get; set; }

        public string Building { get; set; }

        public int Time { get; set; }

        public Dictionary<string, int> Requirements { get; set; }  //string is product lang code, int is count product
        
    }
}
