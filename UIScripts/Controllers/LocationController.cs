using DataBase;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    private GameObject LocationPanel;

    private GameObject tempLocation;

    void Initialize()
    {
        LocationPanel = this.gameObject;
    }

    public void LoadChamomile()
    {
        if (tempLocation != null) Close();
        Initialize();
        LocationPanel.gameObject.SetActive(true);
        tempLocation = Instantiate(Memory.LocationPrefabs["Chamomile"], LocationPanel.transform);
        tempLocation.transform.SetAsFirstSibling();
    }

    public void LoadSage()
    {
        if (tempLocation != null) Close();
        Initialize();
        LocationPanel.gameObject.SetActive(true);
        tempLocation = Instantiate(Memory.LocationPrefabs["Sage"], LocationPanel.transform);
        tempLocation.transform.SetAsFirstSibling();
    }

    public void LoadCow_Bearberry()
    {
        if (tempLocation != null) Close();
        Initialize();
        LocationPanel.gameObject.SetActive(true);
        tempLocation = Instantiate(Memory.LocationPrefabs["Cow_Bearberry"], LocationPanel.transform);
        tempLocation.transform.SetAsFirstSibling();
    }

    public void LoadCalendula()
    {
        if (tempLocation != null) Close();
        Initialize();
        LocationPanel.gameObject.SetActive(true);
        tempLocation = Instantiate(Memory.LocationPrefabs["Calendula"], LocationPanel.transform);
        tempLocation.transform.SetAsFirstSibling();
    }

    public void LoadSeaBuckthorn()
    {
        if (tempLocation != null) Close();
        Initialize();
        LocationPanel.gameObject.SetActive(true);
        tempLocation = Instantiate(Memory.LocationPrefabs["Sea buckthorn"], LocationPanel.transform);
        tempLocation.transform.SetAsFirstSibling();
    }

    public void LoadTansy_BloomingSally()
    {
        if (tempLocation != null) Close();
        Initialize();
        LocationPanel.gameObject.SetActive(true);
        tempLocation = Instantiate(Memory.LocationPrefabs["Tansy_BloomingSally"], LocationPanel.transform);
        tempLocation.transform.SetAsFirstSibling();
    }

    public void Close()
    {
        Destroy(tempLocation);
        tempLocation = null;
        LocationPanel.gameObject.SetActive(false);
    }
}
