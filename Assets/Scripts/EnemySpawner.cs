using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 60f)][SerializeField] float spawnTime;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] AudioClip spawnEnemySFX;
    [SerializeField] int enemiesToSpawn = 10;
    
    bool playing = true;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int enemySpawned = 0;
        AudioSource audioSource = GetComponent<AudioSource>();
        while (enemySpawned < enemiesToSpawn)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            enemySpawned++;
            audioSource.PlayOneShot(spawnEnemySFX);
            yield return new WaitForSecondsRealtime(spawnTime);
        }
    }
}
