using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject enemyPrefab;
    private Vector3 spawnPos = new Vector3(18, -6.5f, 0);
    private PlayerController playerControllerScript;
    private int waveLevel = 1;

    void Start() {
        InvokeRepeating("SpawnEnemy", 1, 8);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnEnemy() {
        if (playerControllerScript.fighting == false) {
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
            EnemyStats InstanceStats = enemyInstance.GetComponent<EnemyStats>();
            /// hacer dinamico el level de los bichos
            InstanceStats.Initialize(waveLevel, 20);
        }
    }
}
