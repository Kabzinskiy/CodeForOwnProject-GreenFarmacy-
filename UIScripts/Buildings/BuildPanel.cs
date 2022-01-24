using Scripts;
using UnityEngine;

public class BuildPanel : MonoBehaviour
{
    
    void Update()
    {
        gameObject.SetActive(CurrentProperties.CommonBuildMode);
    }
}
