using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public Animator animator;

  private EnemyStats enemyStatsScript;
  public GameObject enemy;
  public bool fighting = false;
  private int baseDamage = 5;
  private int damage = 5;

  public int health, maxHealth;
  public int baseHealth = 200;

  public HealthBarController healthBar;

  // AUTO-ATTACK
  private float autoAttackCooldown = 3.0f;
  public float autoAttackCurTime;
  public bool canAutoAttack;

  // LeveUpController
  public int level = 1;
  public int experience = 0;
  public int experienceToNextLevel;

  void Start() {
    experienceToNextLevel = GetExperienceToNextlevel();
    health = baseHealth * level;
    maxHealth = health; 
    healthBar.FullHp(maxHealth);

  }

  void Update() {
    // AUTO ATTACK
    autoAttackCurTime += Time.deltaTime;

    if (enemy != null && CanAutoAttack()) {
      float enemyHp = enemyStatsScript.GetDamage(damage);
      if (enemyHp < 1) {
        enemy = null;
        fighting = false;
        animator.SetBool("IsFighting", false);
      }
    }
  }

  public void LevelUp() {
    level += 1;
    experience = 0;
    experienceToNextLevel = GetExperienceToNextlevel();
    // ver bien la formula
    damage = baseDamage + level;

    maxHealth += 10 * level;
    health += maxHealth * 5 / 100;

    healthBar.SetMaxHealth(maxHealth);
    healthBar.RestoreHp(maxHealth * 5 / 100);
}

  public void GiveExperience(int _exp) {
    experience += _exp;
    if (experience >= experienceToNextLevel) {
      LevelUp();
    }
  }

  private int GetExperienceToNextlevel() {
    // cambiarloa formula matematica
    return  level * 100;
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Enemy")) {
      animator.SetBool("IsFighting", true);
      fighting = true;
      enemy = other.gameObject;
      enemyStatsScript = enemy.GetComponent<EnemyStats>();
      enemyStatsScript.GenerateAggro(gameObject);
    }
  }

  public void TakeDamage(int damage) {
    health -= damage;
    healthBar.OnTakeDamage(damage);
    animator.SetTrigger("IsBeaten");
    if (health < 1) {
      animator.SetBool("IsDead", true);
      // Destroy(gameObject);

      GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
      gameManager.GameOver();
    }
  }

  public bool CanAutoAttack() {
    if(autoAttackCurTime >= autoAttackCooldown) {
      autoAttackCurTime = 0;
      if ( enemy != null ) { 
        animator.SetTrigger("Attack1"); 
      }
      canAutoAttack = true;
      return true;
    } else {
      canAutoAttack = false;
      return false;
    }
  }
}
