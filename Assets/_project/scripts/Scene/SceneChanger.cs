using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] SceneTransition _transit;

    public void ChangeScene(string sceneName) =>
        _transit.Transit(sceneName);
}
