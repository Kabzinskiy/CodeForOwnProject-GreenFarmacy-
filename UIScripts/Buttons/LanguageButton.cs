using System.Collections;
using System.Collections.Generic;
using DataBase;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    [SerializeField] private Text butText;
    
    // Start is called before the first frame update
    public void Initialize()
    {
        butText.text = Memory.Phrases["LanguageButton"].GetValue();
    }

    public void ChangeLang()
    {
        if (Memory.Player.English)
        {
            Memory.Player.English = false;
        }
        else Memory.Player.English = true;
    }
}
