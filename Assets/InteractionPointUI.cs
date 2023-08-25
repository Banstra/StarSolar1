using TMPro;
using UnityEngine;

public class InteractionPointUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private GameObject UIpanel;
    [SerializeField] private TextMeshProUGUI promptText;

    private void Start()
    {
        mainCam = Camera.main;
        UIpanel.SetActive(false);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + (rotation * Vector3.forward), rotation * Vector3.up);
    }
    public bool IsDisplayed = false;
    public void SetUP(string _promptText)
    {
        promptText.text = _promptText;
        UIpanel.SetActive(true);
        IsDisplayed = true;
    }
    public void Close()
    {
        UIpanel.SetActive(false);
        IsDisplayed = false;
    }
}
