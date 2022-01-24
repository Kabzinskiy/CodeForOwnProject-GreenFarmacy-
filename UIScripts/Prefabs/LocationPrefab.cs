using System.Linq;
using DataBase;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class LocationPrefab : MonoBehaviour
{
    [SerializeField] private string LangCode;
    [SerializeField] private Text Title;
    [SerializeField] private Text Desription;
    [SerializeField] private GameObject GoldBlock;
    [SerializeField] private GameObject EnergyBlock;
    [SerializeField] private Button Buy;
    [SerializeField] private Button Go;

    private Location location;

    public void Initialize()
    {
        location = Memory.Locations.First(x => x.LangCode == LangCode);
        Title.text = location.GetName();
        Desription.text = Memory.Phrases["Cost"].GetValue() + ":";

        if (Memory.Player.OpenList.Contains(LangCode))
        {
            GoldBlock.gameObject.SetActive(false);
            Buy.gameObject.SetActive(false);
            EnergyBlock.gameObject.SetActive(true);
            Go.gameObject.SetActive(true);
            Go.GetComponentInChildren<Text>().text = Memory.Phrases["GoTo"].GetValue();
            Buy.GetComponentInChildren<Text>().text = Memory.Phrases["Buy"].GetValue();

            var energyCount = EnergyBlock.GetComponentInChildren<Text>();
            energyCount.text = location.Energy.ToString();

            if (location.Energy <= Memory.Player.CurrentEnergy)
            {
                energyCount.color = Color.white;
                Go.GetComponent<Image>().color = Color.green;
                Go.enabled = true;
            }
            else
            {
                energyCount.color = Color.red;
                Go.GetComponent<Image>().color = Color.gray;
                Go.enabled = false;
            }
        }
        else
        {
            EnergyBlock.gameObject.SetActive(false);
            Go.gameObject.SetActive(false);
            GoldBlock.gameObject.SetActive(true);
            Buy.gameObject.SetActive(true);
            
            var goldCount = GoldBlock.GetComponentInChildren<Text>();
            goldCount.text = location.Cost.ToString();

            if (location.Cost <= Memory.Player.Money)
            {
                goldCount.color = Color.white;
                Buy.GetComponent<Image>().color = Color.green;
                Buy.enabled = true;
            }
            else
            {
                goldCount.color = Color.red;
                Buy.GetComponent<Image>().color = Color.gray;
                Buy.enabled = false;
            }
        }

    }

    public void BuyLocation()
    {
        Memory.Player.Money -= location.Cost;
        Memory.Player.OpenList.Add(location.LangCode);
    }

    public void RemoveEnergy()
    {
        Memory.Player.CurrentEnergy -= location.Energy;
    }

}
