using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isBossAlive = GetComponent<EnemyHealth>().IsBossAlive();
        if (collision.gameObject.tag == "Player" && isBossAlive == false)
        {
            StartCoroutine(LoadNextLevel1());
        }
    }
    IEnumerator LoadNextLevel1()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
