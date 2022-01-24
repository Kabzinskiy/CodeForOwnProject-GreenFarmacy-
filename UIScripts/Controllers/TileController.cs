using System;
using System.Collections.Generic;
using Building;
using DataBase;
using Scripts;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    [SerializeField] private Tilemap buildingGrid;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject BuildPanel;



    [SerializeField] private int width = 10;
    [SerializeField] private int height = 5;
    private Plane groundPlane;
    private Building.Building flyingBuilding = null;


    void Start()
    {
        foreach (var building in Memory.Player.Buildings)
        {
            CurrentProperties.StartBuildingKeys.Add(building.Key);
            StartCoroutine(building.Value.CheckProductCoroutine());
            Instance(building.Value.GetPrefab(), building.Value.Position);
        }
        groundPlane = new Plane(new Vector3(0f, 0f, -1f), Vector3.zero);
    }
    

    public void Update()
    {
        if (flyingBuilding != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);//Input.GetTouch(0).position set past test
            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 posInWorld = ray.GetPoint(position);
                posInWorld.x = (float)Math.Round(posInWorld.x / 2, MidpointRounding.AwayFromZero) * 2; 
                posInWorld.y = (float)Math.Round(posInWorld.y);
                flyingBuilding.Position =
                    CheckBorders(posInWorld) ? posInWorld : flyingBuilding.Position;
            }
        }
    }

    public GameObject Instance(GameObject building, Vector3 position)
    {
        var temp = Instantiate(building, buildingGrid.transform);
        temp.transform.position = position;
        return temp;
    }

    public void StartPlacingPrefab(Building.Building build)
    {
        string key = Guid.NewGuid().ToString();
        CurrentProperties.StartBuildingKeys.Add(key);
        Memory.Player.Buildings.Add(key, build);
        StartCoroutine(build.CheckProductCoroutine());
        Instance(build.GetPrefab(), Vector3.zero);
    }

    

    public void StayBuilding()
    {
        if (CurrentProperties.CanStayBuilding && flyingBuilding != null)
        {
            flyingBuilding.BuildMode = false;
            flyingBuilding = null;
            BuildPanel.gameObject.SetActive(false);
        }
    }

    public bool CheckBorders(Vector3 buildPosition)
    {
        var cameraPosition = mainCamera.transform.position;
        return (buildPosition.x <= cameraPosition.x + width && 
                buildPosition.x >= cameraPosition.x - width &&
                buildPosition.y <= cameraPosition.y + height && 
                buildPosition.y >= cameraPosition.y - height)
                 ? true
                 : false;
    }
    

    public void DestroyBuild()
    {
        Memory.Player.Buildings.Remove(CurrentProperties.CurrentBuildKey);
        CurrentProperties.CommonBuildMode = false;
        BuildPanel.gameObject.SetActive(false);
    }


    public void PlacingDryer()
    {
        if (flyingBuilding != null) DestroyBuild();
        flyingBuilding = new Building.Building
        {
            LangCode = "Dryer",
            Condition = BuildCondition.Empty,
            Lvl = 1,
            Position = Vector3.zero,
            BuildMode = true
        };
        CurrentProperties.CommonBuildMode = true;
        BuildPanel.transform.gameObject.SetActive(true);
        StartPlacingPrefab(flyingBuilding);
    }

    public void PlacingTeaFactory()
    {
        if (flyingBuilding != null) DestroyBuild();
        flyingBuilding = new Building.Building
        {
            LangCode = "TeaFactory",
            Condition = BuildCondition.Empty,
            Lvl = 1,
            Position = Vector3.zero,
            BuildMode = true
        };
        CurrentProperties.CommonBuildMode = true;
        BuildPanel.transform.gameObject.SetActive(true);
        StartPlacingPrefab(flyingBuilding);
    }

    public void PlacingHives()
    {
        if (flyingBuilding != null) DestroyBuild();
        Dictionary<string, int> product = new Dictionary<string, int>();
        product.Add("Honeycomb", 1);
        flyingBuilding = new Building.Building
        {
            LangCode = "Hives",
            Condition = BuildCondition.Empty,
            Lvl = 1,
            Position = Vector3.zero,
            BuildMode = true,
            readyProds = product
        };
        CurrentProperties.CommonBuildMode = true;
        BuildPanel.transform.gameObject.SetActive(true);
        StartPlacingPrefab(flyingBuilding);
    }

    public void PlacingHoneyDriver()
    {
        if (flyingBuilding != null) DestroyBuild();
        Dictionary<string, int> product = new Dictionary<string, int>();
        flyingBuilding = new Building.Building
        {
            LangCode = "HoneyDriver",
            Condition = BuildCondition.Empty,
            Lvl = 1,
            Position = Vector3.zero,
            BuildMode = true
        };
        CurrentProperties.CommonBuildMode = true;
        BuildPanel.transform.gameObject.SetActive(true);
        StartPlacingPrefab(flyingBuilding);
    }
}
