using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public Animator animator;

  private EnemyStats enemyStatsScript;
  public GameObject enemy;
  public bool isFighting = false;
  // public bool isBeaten = false;

  public HealthBarController healthBar;

  // AUTO-ATTACK
  private float autoAttackCooldown = 3.0f;
  public float autoAttackCurTime;

  // LeveUpController
  public int level = 1;
  public int experience = 0;
  public int experienceToNextLevel;

  // Stats
  public int strength;
  public int dexterity;
  public int intelligence;

  private float damage;
  public int minDamage = 4;
  public int maxDamage = 5;

  public int health, maxHealth;
  public int baseHealth = 200;

  public int mana, maxMana;

  public int magicFind;

  // resistences (fire, cold, light, poison)

  void Start() {
    experienceToNextLevel = GetExperienceToNextlevel();
    health = baseHealth * level;
    maxHealth = health; 
    healthBar.FullHp(maxHealth);
  }

  void Update() {
    autoAttackCurTime += Time.deltaTime;
    if (enemy != null && CanAutoAttack()) {
      animator.SetBool("isAttacking", true);
    }
  }

  public void LevelUp() {
    level += 1;
    experience = 0;
    experienceToNextLevel = GetExperienceToNextlevel();

    minDamage = maxDamage + 1;
    maxDamage = minDamage + 5;

    damage = (minDamage + maxDamage / 2);

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
      isFighting = true;
      animator.SetBool("IsFighting", isFighting);
      enemy = other.gameObject;
      enemyStatsScript = enemy.GetComponent<EnemyStats>();
      enemyStatsScript.GenerateAggro(gameObject);
    }
  }

  public void TakeDamage(int damage) {
    health -= damage;
    healthBar.OnTakeDamage(damage);
    /* isBeaten = true; */
    /* animator.SetTrigger("IsBeaten"); */


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
      return true;
    } else {
      return false;
    }
  }

  public void onFinishAttack() {
    animator.SetBool("isAttacking", false);
    int dmg = CalculateDamage();
    float enemyHp = enemyStatsScript.TakeDamage(dmg);
    if (enemyHp < 1) {
      enemy = null;
      isFighting = false;
      animator.SetBool("IsFighting", isFighting);
    }
  }

  public int CalculateDamage() {
    int dmg = Random.Range(minDamage, maxDamage + 1);
    return dmg;
  }
}
