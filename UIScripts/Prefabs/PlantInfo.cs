using DataBase;
using UnityEngine;
using UnityEngine.UI;

public class PlantInfo : MonoBehaviour
{
    public string LangCode;

    [SerializeField] private Text countText;

    public void Initialize()
    {
        if (Memory.Player.Ingredients.ContainsKey(LangCode))
        {
            countText.text = Memory.Phrases["Count"].GetValue() + ": " + Memory.Player.Ingredients[LangCode];
        }
        else
        {
            countText.text = Memory.Phrases["Early"].GetValue();
        }
    }
}
