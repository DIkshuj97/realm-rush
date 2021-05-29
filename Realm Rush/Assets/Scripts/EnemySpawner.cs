using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] AudioClip spawnedEnemySFX;

    [Range(0.1f,120f)]
    public float secondsBetweenSpawns=2f;
    public int noOfEnemiesSpawned = 0;
    public int maxEnemiesSpawned = 5;
    public EnemyMovement enemyPrefab;
    public int noOfEnemiesRemained;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        noOfEnemiesRemained = maxEnemiesSpawned;
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while(noOfEnemiesSpawned<maxEnemiesSpawned)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            noOfEnemiesSpawned++;
            enemy.transform.parent = transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    public void EnemyDestroyed()
    {
        noOfEnemiesRemained--;
    }
}
