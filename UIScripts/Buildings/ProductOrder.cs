using System.Collections.Generic;
using System.Linq;
using DataBase;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ProductOrder : MonoBehaviour
{
    [SerializeField] private List<Image> productSprites;

    [SerializeField] private Text timeText;

    private Building.Building build = null;

    public void Initialize()
    {
        build = Memory.Player.Buildings[CurrentProperties.CurrentBuildKey];
        var Sprites = build.prodsInWork.Select(x =>
        {
            if (Memory.ProductSprites.ContainsKey(x.LangCode))
            {
                return Memory.ProductSprites[x.LangCode];
            }
            return null;
        }).ToList();

        for (int i = 0; i < productSprites.Count; ++i)
        {
            if (i < Sprites.Count && Sprites[i] != null)
            {
                productSprites[i].sprite = Sprites[i];
                productSprites[i].color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                productSprites[i].color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }



    void Update()
    {
        Initialize();
        if (build != null && build.prodsInWork.Count != 0)
        {
            var timeTxt = build.CheckTime();
            timeText.text = timeTxt;
        }
        else
        {
            timeText.text = "00:00:00";
        }
    }
}
