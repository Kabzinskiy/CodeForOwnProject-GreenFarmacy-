using DataBase;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class BuildPrefab : MonoBehaviour
{
    [SerializeField] private string LangCode;
    [SerializeField] private Text Title;
    [SerializeField] private Text Desription;
    [SerializeField] private Text Gold;
    [SerializeField] private Button Build;

    private int cost = 0;
    public void Initialize()
    {
        Title.text = Memory.Phrases[LangCode].GetValue() + ":";
        Desription.text = Memory.Phrases["Cost"].GetValue() + ":";
        Build.GetComponentInChildren<Text>().text = Memory.Phrases["Build"].GetValue();
        cost = CurrentProperties.GetBuildingCost(LangCode, 1);
        Gold.text = cost.ToString();

        if (cost <= Memory.Player.Money)
        {
            Gold.color = Color.white;
            Build.GetComponent<Image>().color = Color.green;
            Build.enabled = true;
        }
        else
        {
            Gold.color = Color.red;
            Build.GetComponent<Image>().color = Color.gray;
            Build.enabled = false;
        }
        
        
    }

    public void RemoveCost()
    {
        Memory.Player.Money -= cost;
    }
}
