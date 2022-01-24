using UnityEngine;
using Savers;

public class ProfileSaver : MonoBehaviour
{
    public void Save()
    {
        PlayerProfileSaver.Save();
    }
}
