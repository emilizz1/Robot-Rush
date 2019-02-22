using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int nextLevelIndex;

    public void LoadNextLevel()
    {
        StartCoroutine(LevelFinished());
    }

    public IEnumerator LevelFinished()
    {
        print("Level finished");
        while(FindObjectsOfType<EnemyMovement>().Length > 0)
        {
            yield return new WaitForSeconds(0.5f);
        }
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
