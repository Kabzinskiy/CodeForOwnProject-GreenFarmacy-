using System.Linq;
using DataBase;
using Scripts;
using UnityEngine;

public class SellIngredientButton : MonoBehaviour
{
    public string LangCode;

    public void Sell()
    {
        if (Memory.Player.Ingredients.ContainsKey(LangCode))
        {
            int temp = Memory.Player.Ingredients[LangCode];
            Memory.Player.TakeAwayIngredients(LangCode, CurrentProperties.SellCount);
            Memory.Player.Money += (temp - Memory.Player.Ingredients[LangCode]) *
                                   Memory.Plants.First(x => x.LangCode == LangCode).Points; //* Memory.Player.GetLvl();
        }
    }
}
