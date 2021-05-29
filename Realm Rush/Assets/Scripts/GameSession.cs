using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;

    int score;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        if (currentindex == 0)
        {
            Destroy(gameObject);
        }

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();      
    }

    public void GetHealth(int health)
    {
        healthText.text = health.ToString();
    }
}
