using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using UnityEngine;
using Random = System.Random;

public class PlantAction : MonoBehaviour
{
    [SerializeField] private string LangCode;

    public void GetParts()
    {
        var rnd = new Random();
        var partsQuant = Memory.Plants.First(x => x.LangCode == LangCode).PartsQuant;
        var count = rnd.Next(partsQuant, partsQuant * 3);
        Memory.Player.AddIngredients(LangCode, count);
    }
}
