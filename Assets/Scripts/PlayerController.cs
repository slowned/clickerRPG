using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private EnemyStats enemyStatsScript;
    public GameObject enemy;
    public bool fighting = false;
    private int damage = 5;

    public float health, maxHealth;
    public int level = 1;
    public int baseHealth = 20;

    public HealthBarController healthBar;

    void Start() {
        health = baseHealth * level;
        maxHealth = health; 
    }

    // cambiarlo a OnTriggerCollision
    private void OnCollisionEnter(Collision other) {
        // empieza animacion de pegar
        if (other.gameObject.CompareTag("Enemy")) {
            fighting = true;
            enemy = other.gameObject;
            enemyStatsScript = enemy.GetComponent<EnemyStats>();
            //enemyStatsScript = GameObject.FindWithTag("Enemy").GetComponent<EnemyStats>();

            if (healthBar) {
                healthBar.onTakeDamage(20);
            }

        }
    } 

    public void TakeDamage() {
        healthBar.onTakeDamage(20);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            TakeDamage();
        }
        if (enemy && Input.GetKeyDown(KeyCode.F)) {
            int enemyHp = enemyStatsScript.GetDamage(damage);
            // lo mate??
            if (enemyHp < 1) {
                enemy = null;
                fighting = false;
            }
        }
    }
}