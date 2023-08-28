using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    protected static string _sceneName;
    private const string _transitSceneName = "TransitScene";

    [SerializeField] GameObject _crossFade;
    [SerializeField] LoadScreen _loadScreen;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == _transitSceneName)
        {
            _crossFade.SetActive(false);
            _loadScreen.Loading(_sceneName);
            _loadScreen.gameObject.SetActive(true);
        }
    }

    public void Transit(string sceneName)
    {
        _sceneName = sceneName;
        SceneManager.LoadScene(_transitSceneName);
    }
}
