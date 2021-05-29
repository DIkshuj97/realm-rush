using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public Canvas LevelCompleteCanvas;
    public Canvas LevelLoseCanvas;

    float timeToWait = 2f;

    void Start()
    {
        LevelCompleteCanvas.enabled = false;
        LevelLoseCanvas.enabled = false;
    }

    private void Update()
    {
        if(FindObjectOfType<EnemySpawner>().noOfEnemiesRemained==0)
        {
            LevelComplete();
        }
    }

    public void LevelComplete()
    {
        StartCoroutine(HandleWinCondition());
    }

    IEnumerator HandleWinCondition()
    {
        LevelCompleteCanvas.enabled = true;
        yield return new WaitForSeconds(timeToWait);
        FindObjectOfType<LevelLoad>().LoadNextLevel();
    }

    public void HandleLoseCondition()
    {
        LevelLoseCanvas.enabled = true;
        Time.timeScale = 0;
    }
}
