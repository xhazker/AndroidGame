using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
    private float TimeSpawn = 1f;
    private Vector2 enemyPos;
    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(TimeSpawn);
        enemyPos = new Vector2(Random.Range(-17.0f, 17.0f), 15);
        Instantiate(Enemy, enemyPos, Quaternion.identity);
        Repeat();
    }
}
