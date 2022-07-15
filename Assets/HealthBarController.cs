using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // using for ProUGUI


public class HealthBarController : MonoBehaviour {
    public Image healthBar;
    public float health;
    public float maxHealth;

    public TextMeshProUGUI healthText;

    void Start() {
      healthText.text = "HP: " + health;
    }

    public void OnTakeDamage(int damage) {
        health = health - damage;
        healthBar.fillAmount = health / maxHealth;
        UpdateText();
    }

    public void FullHp(float _health) {
        health = maxHealth = _health;
        healthBar.fillAmount = 1.0f;
        UpdateText();
    }

    public void RestoreHp(float amount) {
      health += amount;
      healthBar.fillAmount += amount / 100;
      UpdateText();
    }

    private void UpdateText() {
      healthText.text = "HP: " + health;
    }

    public void SetMaxHealth(float _maxHealth) {
      maxHealth = _maxHealth;
    }
}
