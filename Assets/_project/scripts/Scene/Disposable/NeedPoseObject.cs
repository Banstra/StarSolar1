using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NeedPoseObject : MonoBehaviour
{
    [SerializeField] Transform _needObject;

    [SerializeField] Vector3 _needPosition;
    [SerializeField] Vector3 _needRotation;

    public void PosedObject()
    {
        _needObject.localPosition = _needPosition;
        _needObject.rotation = Quaternion.Euler(_needRotation);
    }
}
