using System.Collections;
using System.Collections.Generic;
using DataBase;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private Text butText;

    // Start is called before the first frame update
    public void Initialize()
    {
        butText.text = Memory.Phrases["Exit"].GetValue();
    }

    public void TakeAway()
    {
        Application.Quit();
    }
}
