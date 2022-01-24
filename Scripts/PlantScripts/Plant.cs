using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Button button;

    [SerializeField] private Sprite FirstImage;
    [SerializeField] private Sprite SecondImage;

    void Start()
    {
        button.image.sprite = FirstImage;
    }

    public void ChangeButtonImage()
    {
        button.image.sprite = SecondImage;
    }

}
