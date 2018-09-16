using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 60f)][SerializeField] float spawnTime;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] AudioClip spawnEnemySFX;
    
    bool playing = true;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        while (playing)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            audioSource.PlayOneShot(spawnEnemySFX);
            yield return new WaitForSecondsRealtime(spawnTime);
        }
    }
}
