using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {

  public GameObject enemy;

  public float autoAttackCurTime;
  public float autoAttackCooldown = 3.0f;
  public bool canAutoAttack;

  public float specialAttackCurTime;
  public float specialAttackCooldown;
  public bool canSpecialAttack;

  void Start() {
      
  }

  void Update() {
    if(enemy != null && CanAutoAttack()) {
      enemy.GetComponent<PlayerController>().TakeDamage();
    }
  }

  public void SetEnemy(GameObject _enemy) {
    Debug.Log("seteo enemigo");
    enemy = _enemy;
  }

  private bool CanAutoAttack() {

    if(autoAttackCurTime >= autoAttackCooldown) {
      autoAttackCurTime = 0;
      return true;
    } else {
      autoAttackCurTime += Time.deltaTime;
      return false;
    }
  }
}
