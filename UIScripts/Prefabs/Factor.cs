using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Factor : MonoBehaviour
{
    [SerializeField] private Button factorX1;
    [SerializeField] private Button factorX10;
    [SerializeField] private Button factorX100;

    private Color basic = new Color(0.6f, 0.8f, 0.35f, 1f);
    private Color shadow = new Color(0.4f, 0.5f, 0.2f, 1f);

    public void Initialize()
    {
        var imageX1 = factorX1.GetComponent<Image>();
        var imageX10 = factorX10.GetComponent<Image>();
        var imageX100 = factorX100.GetComponent<Image>();
        switch (CurrentProperties.SellCount)
        {
            case 1:
                imageX1.color = shadow;
                imageX10.color = basic;
                imageX100.color = basic;
                break;
            case 10:
                imageX1.color = basic;
                imageX10.color = shadow;
                imageX100.color = basic;
                break;
            case 100:
                imageX1.color = basic;
                imageX10.color = basic;
                imageX100.color = shadow;
                break;
            default:
                CurrentProperties.SellCount = 1;
                imageX1.color = shadow;
                imageX10.color = basic;
                imageX100.color = basic;
                break;
        }
    }

    public void ClickX1()
    {
        CurrentProperties.SellCount = 1;
        Initialize();
    }

    public void ClickX10()
    {
        CurrentProperties.SellCount = 10;
        Initialize();
    }

    public void ClickX100()
    {
        CurrentProperties.SellCount = 100;
        Initialize();
    }
}
