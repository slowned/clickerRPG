using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

  private HealthBarController healthBar;
  public CombatController combatControllerScript;

  private float baseHealth = 20;
  private int baseDamage = 3;

  public float health;
  public float maxHealth;
  public int level;
  public int damage;
  public int defense;


  public float GetDamage(int damage) {
      health -= damage;
      healthBar.OnTakeDamage(damage);
      if (health < 1) {
          SpawnManager spawnManger = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
          spawnManger.enemyKilled();
          // Destroy(gameObject);
      }
      return health;
  }
  
  public void SetStats(int _level) {
      level = defense = _level;
      maxHealth = health = baseHealth * _level;
      damage = baseDamage * level + defense;

      healthBar = GameObject.FindWithTag("EnemyHealthBar").GetComponent<HealthBarController>();
      healthBar.FullHp(maxHealth);
      // dmg = _dmg * lvl 
  }

  public void GenerateAggro(GameObject _enemy) {
    combatControllerScript = gameObject.GetComponent<CombatController>();
    combatControllerScript.SetEnemy(_enemy);
    combatControllerScript.SetMe(gameObject);
  }

  public int GetDamage() {
    return damage;
  }
}
