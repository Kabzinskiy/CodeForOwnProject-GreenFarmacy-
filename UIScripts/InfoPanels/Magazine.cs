using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    [SerializeField] private List<BuildPrefab>  prefabs;

    public void Initialize()
    {
        foreach (var prefab in prefabs)
        {
            prefab.Initialize();
        }
    }
}
