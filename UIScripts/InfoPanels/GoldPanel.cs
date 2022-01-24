using DataBase;
using UnityEngine;
using UnityEngine.UI;

public class GoldPanel : MonoBehaviour
{
    [SerializeField] private Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = Memory.Player.Money.ToString();
    }
}
