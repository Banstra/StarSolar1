using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCrutch : MonoBehaviour
{
    [SerializeField] Transform _cam;
    void Update()
    {
        var camRotation = new Vector3(0, _cam.rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(camRotation);
    }
}
