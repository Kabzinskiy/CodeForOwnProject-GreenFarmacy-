using DataBase;

namespace Plants
{
    public class Plant
    {
        public string LangCode { get; set; }
        public int Points { get; set; }
        public int PartsQuant { get; set; }

    }

    public class PlantDisplay
    {
        private Plant plant = new Plant();

        public string Name
        {
            get
            {                
                return Memory.Phrases[plant.LangCode]?.GetValue();
            }
        }

        public PlantsSet Sprites
        {
            get
            {
                return Memory.PlantsSprites[plant.LangCode];
            }
        }
        PlantDisplay(Plant plant)
        {
            this.plant = plant;
        }
    }
}
