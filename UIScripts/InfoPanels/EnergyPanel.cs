using DataBase;
using UnityEngine;
using UnityEngine.UI;

public class EnergyPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    void Update()
    {
        text.text = Memory.Player.CurrentEnergy.ToString();
    }
}
