using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    public Image healthBar;
    public float health;
    public float maxHealth;

    void Start() {
    }

    public void onTakeDamage(int damage) {
        health = health - damage;
        healthBar.fillAmount = health / maxHealth;
    }

    public void fullHp() {
        health = maxHealth;
        healthBar.fillAmount = 1.0f;
    }
}
