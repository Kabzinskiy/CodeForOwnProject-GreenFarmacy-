using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStyled : MonoBehaviour
{
    private Button button;
    private Image img;

    void Awake()
    {
        button = GetComponent<Button>();
        img = GetComponent<Image>();
    }

    public void SetActivity()
    {
        button.enabled = true;
        img.color = new Color(1f, 1f, 1f, 1f);
    }

    public void SetDisactivity()
    {
        button.enabled = false;
        img.color = new Color(1f, 1f, 1f, 0.3f);
    }

}
