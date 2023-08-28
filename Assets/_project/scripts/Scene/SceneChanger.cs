using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }

    [SerializeField] SceneTransition _transit;

    private void Start() =>
        Instance = this;

    public void ChangeScene(string sceneName) =>
        _transit.Transit(sceneName);
}
