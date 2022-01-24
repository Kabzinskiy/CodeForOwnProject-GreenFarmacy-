using System.Collections.Generic;
using DataBase;

namespace Profile
{
    public class PlayerProfiles
    {
        public bool English = false;

        public bool SoundOn = false;
        public Dictionary<string, Building.Building> Buildings { get; set; } //string is uniq Id building
        public long PlayerExperience { get; set; }

        public List<string> OpenList = new List<string>();

        private int currentEnergy = 10;
        public int CurrentEnergy
        {
            get
            {
                return currentEnergy;
            }
            set
            {
                currentEnergy = value;
                var max = GetMaxEnergy();
                currentEnergy = currentEnergy < 0 ? 0 : currentEnergy;
                currentEnergy = (currentEnergy > max) ?  max : currentEnergy;
            }
        }

        public Dictionary<string, int> Ingredients { get; set; } = new Dictionary<string, int>();
        public long Money { get; set; } = 50;

        public int GetLvl()
        {
            int lvl = 1;
            foreach (var exp in Memory.PlayerLevels)
            {
                if (PlayerExperience <= exp.Key)
                {
                    lvl = exp.Value;
                }
            }
            return lvl;
        }

        public int GetMaxEnergy()
        {
            return 10 + GetLvl() * 10;
        }

        public void AddIngredients(string LangCode, int count)
        {
            if (!Ingredients.ContainsKey(LangCode))
            {
                Ingredients.Add(LangCode, 0);
            }

            Ingredients[LangCode] += count;
        }

        public void TakeAwayIngredients(string LangCode, int count)
        {
            if (Ingredients.ContainsKey(LangCode))
            {
                Ingredients[LangCode] -= count;
                if (Ingredients[LangCode] < 0) Ingredients[LangCode] = 0;
            }
        }
    }
}
