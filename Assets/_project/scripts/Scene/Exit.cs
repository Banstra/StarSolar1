using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void ChangeScene()
    {
        SceneChanger.Instance.ChangeScene(_sceneName);
    }      
}
