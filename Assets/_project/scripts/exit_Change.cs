using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_Change : MonoBehaviour
{
    private bool collided = false;
    [SerializeField] string SceneName;
    public Animator transition;
    [SerializeField] float amountOfSeconds;

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
    }
    private void Update()
    {
        if (collided)
        {
            LoadTheScene();
        }
    }

  public void LoadTheScene()
    {
        StartCoroutine(LoadLevel());
    }
 
    IEnumerator LoadLevel ()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(amountOfSeconds);
        SceneManager.LoadScene(SceneName);
    }
}
