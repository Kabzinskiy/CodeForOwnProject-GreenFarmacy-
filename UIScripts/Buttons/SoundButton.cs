using System.Collections;
using System.Collections.Generic;
using DataBase;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Text butText;

    // Start is called before the first frame update
    public void Initialize()
    {
        if (Memory.Player.SoundOn)
        {
            butText.text = Memory.Phrases["SoundButtonOn"].GetValue();
        }
        else butText.text = Memory.Phrases["SoundButtonOff"].GetValue();
    }

    public void ChangeSound()
    {
        if (Memory.Player.SoundOn)
        {
            Memory.Player.SoundOn = false;
        }
        else Memory.Player.SoundOn = true;
    }
}
