using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehousePanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<HerbsItem> herbs;
    [SerializeField] private Factor factor;

    public void Initialize()
    {
        foreach (var herb in herbs)
        {
            herb.Initialize();
            factor.Initialize();
        }
    }
}
