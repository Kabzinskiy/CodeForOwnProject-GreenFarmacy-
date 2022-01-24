using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    public class Product
    {
        public string LangCode { get; set; }
        public int Count { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Product(string langCode, int count, DateTime startTime ,  int productionTime)
        {
            LangCode = langCode;
            Count = count;
            StartTime = startTime;
            EndTime = StartTime.AddSeconds(productionTime);
        }
    }
}
