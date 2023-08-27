using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _camera;
    [SerializeField] Vector3 _positionDifference;
    [SerializeField] Vector3 _maxPositionDifference;
    [SerializeField] float _speed;
    [SerializeField] string _playerTag;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        var mouseX = Input.GetAxis(InputStrings.MouseXAxis);
        var mouseY = Input.GetAxis(InputStrings.MouseYAxis);

        _positionDifference += transform.up * mouseY * _speed + transform.right * mouseX * _speed;
        _positionDifference = new Vector3(
            Mathf.Abs(_positionDifference.x) > _maxPositionDifference.x ? _maxPositionDifference.x * (_positionDifference.x > 0 ? 1 : -1) : _positionDifference.x,
            Mathf.Abs(_positionDifference.y) > _maxPositionDifference.y ? _maxPositionDifference.y * (_positionDifference.y > 0 ? 1 : -1) : _positionDifference.y,
            Mathf.Abs(_positionDifference.z) > _maxPositionDifference.z ? _maxPositionDifference.z * (_positionDifference.z > 0 ? 1 : -1) : _positionDifference.z
            );
        transform.position = _target.position + _positionDifference;
        _camera.LookAt(_target);
        //transform.rotation = Quaternion.Euler(new Vector3(0, _camera.rotation.eulerAngles.y));
    }
}
