using System.Collections.Generic;
using DataBase;
using JetBrains.Annotations;
using UnityEngine;
using BuildColors;
using Scripts;

public class BuildingGizmos : MonoBehaviour
{
    
    [SerializeField] private int gridHeight;
    [SerializeField] private int gridWidth;
    [SerializeField] [CanBeNull] private Grid grid;

    private GameObject building;
    private List<GameObject> tileSet;
    private Sprite tileSprite;
    private Building.Building Obj;
    private int colliderEnteringCount = 0;
    private bool IsColorClearing = false;
    

    

    private static Dictionary<color, Color> colors = new Dictionary<color, Color>
    {
        {color.red, new Color(1f, 0f, 0f, 0.2f)},
        {color.green, new Color(0f, 1f, 0f, 0.2f)},
        {color.clear, new Color(0f, 0f, 0f, 0f)}
    };

    void Start()
    {
        tileSprite = Memory.Tile;
        building = this.gameObject;
        GenerateGrid();
        if (Memory.Player.Buildings.ContainsKey(CurrentProperties.CurrentBuildKey))
        {
            Obj = Memory.Player.Buildings[CurrentProperties.CurrentBuildKey];
        }
        else
        {
            Obj = null;
        } 

        if (Obj != null && Obj.BuildMode == true)
        {
            SetColor(color.green);
        }
        else
        {
            SetColor(color.clear);
        }
    }


    void Update()
    {
        if (Obj == null || (!IsColorClearing && Obj.BuildMode == false))
        {
            SetColor(color.clear);
            IsColorClearing = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ++colliderEnteringCount;
        CurrentProperties.CanStayBuilding = false;
        SetColor(color.red);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        --colliderEnteringCount;
        if (colliderEnteringCount != 0) return;
        CurrentProperties.CanStayBuilding = true;
        SetColor(Obj?.BuildMode == true ? color.green : color.clear);
    }

    private void GenerateGrid()
    {
        tileSet = new List<GameObject>();
        GameObject gizmo = new GameObject("Gizmo");
        gizmo.transform.SetParent(building.transform);

        float halfWidthTile = grid != null ? grid.cellSize.x / 2f : 1f;
        float halfHeightTile = grid != null ? grid.cellSize.y / 2f : 0.5f;
        Vector2 startCoord = new Vector2(-halfWidthTile * gridHeight + building.transform.position.x, building.transform.position.y);

        for (int width = 0; width < gridWidth; ++width)
        {
            for (float height = 0, x = startCoord.x, y = startCoord.y; height < gridHeight; ++height, x+= halfWidthTile, y+= halfHeightTile)
            {
                GameObject tile = new GameObject("Tile");
                SpriteRenderer pict = tile.AddComponent<SpriteRenderer>();
                
                pict.sprite = tileSprite;
                tile.transform.SetParent(gizmo.transform);
                tile.transform.position = new Vector3(x, y, 0);
                
                pict.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                pict.sortingLayerName = "BackgroundLayer";
                pict.sortingOrder = 0;
                tileSet.Add(tile);
            }

            startCoord.x += halfWidthTile;
            startCoord.y -= halfHeightTile;
        }
        
    }

    private void SetColor(color clr)
    {
        if (clr == null) clr = color.clear;
        foreach (var tile in tileSet)
        {
            tile.GetComponent<SpriteRenderer>().color = colors[clr];
        }
    }


}
