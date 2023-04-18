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

  public int experience;


  public float TakeDamage(int damage) {
    health -= damage;
    healthBar.OnTakeDamage(damage);

    if (health < 1) {

      PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
      player.GiveExperience(experience);
      SpawnManager spawnManger = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
      spawnManger.EnemyKilled();

    }
    return health;
  }
  
  public void SetStats(int _level) {
    level = defense = _level;
    maxHealth = health = baseHealth * _level;
    damage = baseDamage * level + defense;

    healthBar = GameObject.FindWithTag("EnemyHealthBar").GetComponent<HealthBarController>();
    healthBar.FullHp(maxHealth);

    experience = level * 10;
  }

  public void GenerateAggro(GameObject _enemy) {
    combatControllerScript = gameObject.GetComponent<CombatController>();
    combatControllerScript.SetEnemy(_enemy);
    combatControllerScript.SetMe(gameObject);
  }

  public int GetDamage() {
    return damage;
  }

  public float getHealth() {
    return health;
  }
}
