using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private bool collided = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!collided && other.TryGetComponent(out SceneChanger player))
        {
            collided = true;
            player.ChangeScene(_sceneName);
        }
    }
}
