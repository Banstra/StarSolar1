using TMPro;
using UnityEngine;

public class InteractionPointUI : MonoBehaviour
{
    [SerializeField] private GameObject UIpanel;
    [SerializeField] private TextMeshProUGUI promptText;

    private void Start()
    {
        UIpanel.SetActive(false);
    }

    public void SetUP(string _promptText)
    {
        promptText.text = _promptText;
        UIpanel.SetActive(true);
    }

    public void Close() =>
        UIpanel.SetActive(false);
}
