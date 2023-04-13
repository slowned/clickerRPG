using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {

  public GameObject enemy;
  public GameObject fighter;
  public Animator animator;

  public float autoAttackCurTime;
  public float autoAttackCooldown = 3.0f;
  public bool canAutoAttack;

  public float specialAttackCurTime;
  public float specialAttackCooldown;
  public bool canSpecialAttack;



  void Update() {
    if(enemy != null && CanAutoAttack()) { 
        
        enemy.GetComponent<PlayerController>().TakeDamage(
        fighter.GetComponent<EnemyStats>().GetDamage());        

        }
  }

  public void SetEnemy(GameObject _enemy) {
    enemy = _enemy;
  }

  public void SetMe(GameObject _fighter) {
    fighter = _fighter;
  }

  private bool CanAutoAttack() {
        EnemyStats es = gameObject.GetComponent<EnemyStats>();       
      if (autoAttackCurTime >= autoAttackCooldown & es.isHiten == false) {
      autoAttackCurTime = 0;
      if (enemy != null)
      {
         animator.SetTrigger("IsAttacking");
      }
      return true;
    } else {
      autoAttackCurTime += Time.deltaTime;
      return false;
    }
  }
}
