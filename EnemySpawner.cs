using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;

    private float distance = 0;
    private float distanceUsed = 0;


    void Update() {
        if (Mathf.Abs(distance) < Mathf.Abs(transform.position.x * 2)) {
            distance = transform.position.x * 2;
            Debug.Log("1");
        }
        Debug.Log(transform.position.x * 2);

        float distToGo = Mathf.FloatToHalf(distance - distanceUsed);

        if (Mathf.Abs(distanceUsed) < Mathf.Abs(distance) && distToGo > 4) {
            distanceUsed = distance;
            Debug.Log("guiguygiu");
            SpawnEnemy();
        }
    }


    private void SpawnEnemy() {
        float yPos = Mathf.Floor(Mathf.Abs(UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f)) * (1 + 100 - (-2)) * (-2));
        Vector2 posToSpawnEnemy = new Vector2(distance, yPos);
        Debug.Log("2");
        Instantiate(enemy, posToSpawnEnemy, Quaternion.identity);
    }
}
