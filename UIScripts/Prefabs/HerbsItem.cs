using System.Linq;
using DataBase;
using UnityEngine;
using UnityEngine.UI;

public class HerbsItem : MonoBehaviour
{
    public string LangCode;

    [SerializeField] private SellIngredientButton sellButton;
    [SerializeField] private PlantInfo info;
    [SerializeField] private Text cost;
    public void Initialize()
    {
        sellButton.LangCode = LangCode;
        info.LangCode = LangCode;
        cost.text = Memory.Phrases["CostPerOne"].GetValue() + ": " +
                    Memory.Plants.First(x => x.LangCode == LangCode).Points;
        info.Initialize();
    }

}
