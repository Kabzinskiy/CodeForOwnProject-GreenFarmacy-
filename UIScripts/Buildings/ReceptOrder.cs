using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ReceptOrder : MonoBehaviour
{
    [SerializeField] private List<Image> recepts;
    [SerializeField] private Text RecDescription;
    [SerializeField] private ButtonStyled button;

    private Image tempRecept;
    private Building.Building build = null;

    public void Initialize()
    {
        build = Memory.Player.Buildings[CurrentProperties.CurrentBuildKey];
        var buildRecepts = Memory.Recepts.Where(x => x.Building == build.LangCode).ToList();

        for (int i = 0; i < recepts.Count; ++i)
        {
            string prodLangCode = null;
            if (i < buildRecepts.Count)
            {
                prodLangCode = buildRecepts[i].LangCode;
            }

            if (prodLangCode != null && Memory.ProductSprites.ContainsKey(prodLangCode))
            {
                recepts[i].gameObject.SetActive(true);
                recepts[i].sprite = Memory.ProductSprites[prodLangCode];
                recepts[i].color = new Color(1f, 1f, 1f, 1f);
                recepts[i].GetComponent<Button>().enabled = true;
            }
            else
            {
                recepts[i].gameObject.SetActive(false);
            }
                
        }
        
        tempRecept = recepts[0];
        Selecting();
        InitializeRecept();
    }

    

    public void ActiveRecept_0()
    {
        tempRecept = recepts[0];
        Selecting();
        InitializeRecept();
    }

    public void ActiveRecept_1()
    {
        tempRecept = recepts[1];
        Selecting();
        InitializeRecept();
    }

    public void ActiveRecept_2()
    {
        tempRecept = recepts[2];
        Selecting();
        InitializeRecept();
    }

    public void ActiveRecept_3()
    {
        tempRecept = recepts[3];
        Selecting();
        InitializeRecept();
    }

    public void AddProduct()
    {
        build.AddProduction(tempRecept.sprite.name);
        InitializeRecept();
    }

    private void Selecting()
    {
        foreach (var recept in recepts)
        {
            recept.color = new Color(1f, 1f, 1f, 1f);
        }
        tempRecept.color = new Color(0.6f, 0.6f, 0.6f, 1f);
    }

    private void InitializeRecept()
    {
        var receptName = tempRecept.sprite.name;
        var currentRecept = Memory.Recepts.First(x => x.LangCode == receptName);
        var requirements = currentRecept.Requirements;

        string textReq = "Requirements:\n";
        foreach (var req in requirements)
        {
            textReq += req.Value + " " + req.Key + "\n";
        }
        textReq += "Production time = " + currentRecept.Time;
        RecDescription.text = textReq;


        if (build.IsCanToProduction(receptName))
        {
            button.SetActivity();
            RecDescription.color = new Color(0.5f, 0.4f, 0.2f);
        }
        else
        {
            button.SetDisactivity();
            RecDescription.color = Color.red;
        }

    }
}
