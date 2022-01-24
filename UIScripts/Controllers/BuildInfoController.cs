using UnityEngine;

public class BuildInfoController : MonoBehaviour
{
    [SerializeField] private GameObject BuildInfo;
    [SerializeField] private ReceptPanel panel;

    public void Show()
    {
        BuildInfo.gameObject.SetActive(true);
        panel.Initialize();
    }
}
