using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns = 2f;
  
    void Start()
    {
        StartCoroutine(SpawnerEnemyCoroutine());
    }

    private IEnumerator SpawnerEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Transform spawPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, spawPoint.position,Quaternion.identity);
        }
    }
    
}
