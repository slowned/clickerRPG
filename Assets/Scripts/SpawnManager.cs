using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour {
  public GameObject enemyPrefab;
  public GameObject enemy;
  private Vector3 spawnPos = new Vector3(18, -6.5f, 0);
  private Vector3 offSetSpawnPos = new Vector3(10, 0, 0);
  private PlayerController playerControllerScript;

  public int waveLevel;
  private int cantEnemyBase = 1;
  public int waveToBoss = 1;
  private int toKill;
  public int enemiesToSpawn;
  public int enemiesToKill;

  public Vector3 bossScale = new Vector3(4.0f, 4.0f, 4.0f);

  private GameManager gameManager;

  void Start() {
    WaveSpawnLevel();
    InvokeRepeating("SpawnEnemy", 1, 8);
    playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
  }

  // IEnumerator SpawnEnemy() { while(gameManager.isGameActive) }
  void SpawnEnemy() {
    if (playerControllerScript.fighting == false) {
      enemy = Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
      EnemyStats InstanceStats = enemy.GetComponent<EnemyStats>();
      if (IsBossWave() && enemiesToKill == 1) {
        enemy.transform.localScale = bossScale;
        waveToBoss = 1;
        //Transform scale = enemy.GetComponent<Transform>();
      }
      InstanceStats.SetStats(waveLevel);
    }
  }

  private int EnemiesToSpawn() {
    return cantEnemyBase + waveLevel;
  }

  private bool IsBossWave() {
    if (waveToBoss != 0) {
      return false;
    }
    return true;
  }

  private void WaveSpawnLevel() {
    /* sube 1 lvl y setea la cantidad de enemigos en la wave */
    waveLevel += 1;
    // Definir si es la wave hay un boss osea 4 chobis y un boss
    //  o el boss esta solo en la wave.
    enemiesToSpawn = EnemiesToSpawn();
    enemiesToKill = enemiesToSpawn;
  }

  public void enemyKilled() {
    enemiesToKill -= 1;
    gameManager.UpdateScore();
    Destroy(enemy);
    if (enemiesToKill < 1) {
      WaveSpawnLevel();
      waveToBoss -= 1;
    }
  }

  /* CREA WAVE ENTERA */

  /* private void SpawnEnemyWave() { */
  /*   /* */
  /*    * waveLevel: 1 */
  /*    * cantEnemies: 3 */
  /*    * boss: false */
  /*    *1/ */
  /*   enemiesToSpawn = EnemiesToSpawn(); */
  /*   toKill = enemiesToSpawn; */

  /*   for (int i = 1; i <= enemiesToSpawn; i++) { */
  /*     enemyPrefab = Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation); */
  /*     EnemyStats InstanceStats = enemyPrefab.GetComponent<EnemyStats>(); */
  /*     InstanceStats.SetStats(waveLevel); */

  /*     spawnPos += offSetSpawnPos; */
  /*   } */

  /*   waveLevel += 1; */
  /* } */
}
