using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MainBuilding : MonoBehaviour
{
    [SerializeField] private List<Image> productImages;

    private GameObject building;
    private string OwnKey;
    private Building.Building Obj;
    private BuildInfoController panel;

    void Start()
    {
        CurrentProperties.CurrentBuildKey = CurrentProperties.StartBuildingKeys.First();
        CurrentProperties.StartBuildingKeys.Remove(CurrentProperties.CurrentBuildKey);
        building = this.gameObject;
        OwnKey = CurrentProperties.CurrentBuildKey;
        Obj = Memory.Player.Buildings[OwnKey];
        panel = GameObject.Find("BuildInfoPanel").GetComponent<BuildInfoController>();
    }

    // Update is called once per frame
    void Update()
    {
        InitializeProducts();
        if (!Memory.Player.Buildings.ContainsKey(OwnKey)) Destroy(building);
        if (Obj.BuildMode)
        {
            building.transform.position = Obj.Position;
        }
    }

    public void OpenPanel()
    {
        if (Obj.BuildMode) return;
        if (Obj.readyProds.Count == 0)
        {
            CurrentProperties.CurrentBuildKey = OwnKey;
            panel.Show();
        }
        else Obj.TakeProductsToPlayer();
    }

    public void InitializeProducts()
    {
        Color activity = Obj?.readyProds?.Count == 0 ? new Color(1f,1f,1f,0f) : new Color(1f, 1f, 1f, 1f);
        foreach (var productImage in productImages)
        {
            productImage.color = activity;
        }
    }
}
