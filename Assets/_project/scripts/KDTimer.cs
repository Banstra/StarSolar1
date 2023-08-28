using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KDTimer : MonoBehaviour
{
    [SerializeField] protected float timeKD;
    protected bool _isReady = true;
    protected IEnumerator CheckKD()
    {
        _isReady = false;
        yield return new WaitForSeconds(timeKD);
        _isReady = true;
    }
}
