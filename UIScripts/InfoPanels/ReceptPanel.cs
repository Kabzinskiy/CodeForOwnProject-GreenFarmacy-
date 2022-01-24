using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptPanel : MonoBehaviour
{
    [SerializeField] private ReceptOrder orderRecepts;
    public void Initialize()
    {
        orderRecepts.Initialize();
    }
}
