using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private LanguageButton langBut;
    [SerializeField] private SoundButton soundBut;
    [SerializeField] private ExitButton exitBut;
    public void Initialize()
    {
        langBut.Initialize();
        soundBut.Initialize();
        exitBut.Initialize();
    }
}
