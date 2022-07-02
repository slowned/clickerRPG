using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // using for ProUGUI


public class HealthBarController : MonoBehaviour {
    public Image healthBar;
    private float health;
    private float maxHealth;

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

    private void RestoreHp(float amount) {
      health += amount;
    }

    private void UpdateText() {
      healthText.text = "HP: " + health;
    }
}
