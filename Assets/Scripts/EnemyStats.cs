using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    private HealthBarController healthBar;
    public CombatController combatController;

    public int health;
    public int maxHealth;
    public int level;
    // public dmg

    public int GetDamage(int damage) {
        health -= damage;
        healthBar.onTakeDamage(damage);
        if (health < 1) {
            Destroy(gameObject);
        }
        return health;
    }
    
    public void Initialize(int _level, int _health) {
        level = _level;
        maxHealth = health = _health;
        healthBar = GameObject.FindWithTag("EnemyHealthBar").GetComponent<HealthBarController>();
        healthBar.fullHp();
        // dmg = _dmg * lvl 
    }

    public void GenerateAggro(GameObject _enemy) {
      Debug.Log("e loquieto vo wa a matar");
      combatController = gameObject.GetComponent<CombatController>();
      combatController.SetEnemy(_enemy);
    }
}
