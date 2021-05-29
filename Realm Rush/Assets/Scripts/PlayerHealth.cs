using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] AudioClip playerDamageSFX;

    private void Start()
    {
        health = FindObjectOfType<EnemySpawner>().maxEnemiesSpawned;
        FindObjectOfType<GameSession>().GetHealth(health);   
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health -= healthDecrease;
        FindObjectOfType<GameSession>().GetHealth(health);
        if (health<=0)
        {
            FindObjectOfType<GameStatus>().HandleLoseCondition();
        }
    }
}
