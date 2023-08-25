using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_Change : MonoBehaviour
{
    private bool collided = false;
    [SerializeField] private string SceneName;
    public Animator transition;

    private void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            collided = true;
            LoadTheScene();
        }
    }

    public void LoadTheScene() =>
          StartCoroutine(LoadLevel());

    private IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        var async = SceneManager.LoadSceneAsync(SceneName);
        yield return new WaitWhile(() => !async.isDone);
    }
}
