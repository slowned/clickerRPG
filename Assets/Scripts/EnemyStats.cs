using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    private HealthBarController healthBar;
    public CombatController combatControllerScript;
    public Animator animator;

    private float baseHealth = 20;
    private int baseDamage = 3;

    public float health;
    public float maxHealth;
    public int level;
    public int damage;
    public int defense;

    public int experience;

    private float espadaProbabilidad = 0.001f; // 0.10%
    private float pocionProbabilidad = 0.4f; // 1%
    private float cascoProbabilidad = 0.002f; // 0.20%  

    public bool isHiten = false;



    public float TakeDamage(int damage)
    {


        isHiten = true;
        health -= damage;
        healthBar.OnTakeDamage(damage);
        animator.SetTrigger("IsTakingHit");



        if (health < 1)
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
            player.GiveExperience(experience);
            SpawnManager spawnManger = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            GetComponent<Collider2D>().enabled = false;
            animator.SetBool("IsDeath", true);
            DropItem();
            spawnManger.EnemyKilled();
            GetComponent<CombatController>().enabled = false;


        }
        return health;

    }

    public void DropItem()
    {
        // Aqu� va el c�digo para matar al enemigo

        // Determina si el enemigo deja caer un objeto

        float randomValue = Random.Range(0f, 1f);


        if (randomValue < espadaProbabilidad)
        {
            // Deja caer una espada
            //Instantiate(espadaPrefab, transform.position, Quaternion.identity);
            Debug.Log("Te tiro una espada");
        }
        else if (randomValue < pocionProbabilidad)
        {
            // Deja caer una pocion de vida
            //Instantiate(pocionPrefab, transform.position, Quaternion.identity);
            Debug.Log("Te tiro una pocion");


        }
        else if (randomValue < cascoProbabilidad)
        {
            // Deja caer un casco
            //Instantiate(cascoPrefab, transform.position, Quaternion.identity);
            Debug.Log("Te tiro un casco");
        }
        else
        {
            Debug.Log("No tiro nada");
        }

    }
    public void SetStats(int _level)
    {
        level = defense = _level;
        maxHealth = health = baseHealth * _level;
        damage = baseDamage * level + defense;

        healthBar = GameObject.FindWithTag("EnemyHealthBar").GetComponent<HealthBarController>();
        healthBar.FullHp(maxHealth);

        experience = level * 10;
    }

    public void GenerateAggro(GameObject _enemy)
    {
        combatControllerScript = gameObject.GetComponent<CombatController>();
        combatControllerScript.SetEnemy(_enemy);
        combatControllerScript.SetMe(gameObject);

    }

    public int GetDamage()
    {
        return damage;
    }

    public float getHealth() {
    return health;
  }

}
