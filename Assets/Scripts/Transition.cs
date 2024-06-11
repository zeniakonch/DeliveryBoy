using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    AsyncOperation _asyncOperation;
    [FormerlySerializedAs("LoadBar")] public Image loadBar;
    [FormerlySerializedAs("BarTxt")] public Text barTxt;
    [FormerlySerializedAs("ScenId")] public int scenId;

    void Start()
    {
        StartCoroutine(LoadSceneCor());
    }

    IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(1f);
        _asyncOperation = SceneManager.LoadSceneAsync(scenId);
        while (_asyncOperation != null && !_asyncOperation.isDone)
        {
            float progress = _asyncOperation.progress / 0.9f;
            loadBar.fillAmount = progress;
            barTxt.text = "Загрузка  " + string.Format("{0:0}%", progress * 100f);
            yield return 0;
        }
    }
}