using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkstarClearCheck : MonoBehaviour
{
    [SerializeField] float _propsCount;
    [SerializeField] string _cutsceneName;

    private int _countUsedProps = 0;

    public void UseProp()
    {
        _countUsedProps++;
        if (_countUsedProps >= _propsCount)
            CutsceneStart.Start(_cutsceneName);

    }
}
