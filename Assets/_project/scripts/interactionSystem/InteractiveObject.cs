using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : KDTimer
{
    [SerializeField] bool _isDisposable;

    [SerializeField] GameObject _interactiveText;
    [SerializeField] bool _isLookAtCam = true;

    [SerializeField] UnityEvent _interactiveEvent;
    [SerializeField] UnityEvent _enterEvent;
    [SerializeField] UnityEvent _exitEvent;

    private void Update()
    {
        if (_isLookAtCam)
            _interactiveText.transform.LookAt(Camera.main.transform.position);
    }
    private void OnTriggerEnter(Collider _)
    {
        _interactiveText.SetActive(true);
        _enterEvent.Invoke();
    }

    private void OnTriggerExit(Collider _)
    {
        _interactiveText.SetActive(false);
        _exitEvent.Invoke();
    }

    private void OnTriggerStay(Collider _)
    {
        if (_isReady && Input.GetAxis(InputStrings.InteractionAxis) == 1)
        {
            _interactiveEvent.Invoke();
            if (_isDisposable) Destroy(gameObject);
            StartCoroutine(CheckKD());
        }
    }


}
