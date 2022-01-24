using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    [SerializeField] private List<LocationPrefab> prefabs;

    public void Initialize()
    {
        foreach (var prefab in prefabs)
        {
            prefab.Initialize();
        }
    }
}
