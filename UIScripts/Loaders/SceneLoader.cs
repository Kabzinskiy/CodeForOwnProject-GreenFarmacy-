using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Loaders;

public class SceneLoader : MonoBehaviour
{
    private string loadingWord = "Загрузка...";
    [SerializeField] private Image progrBar;
    [SerializeField] private TextMeshProUGUI progrText;
    private static float progess = 0;
    private static float count = 0;

   
    void Start()
    {
        StartCoroutine(Loading());
    }
    public IEnumerator Loading()
   {

        foreach (var loader in LoadingList.loaders)
        {
            loader.Load();
            ++count;
            progess = count / LoadingList.loaders.Count;
            progrBar.fillAmount = progess;
            progrText.text = loadingWord + Mathf.RoundToInt(progess*100) + "%";
            yield return null;
        }

    }
}
