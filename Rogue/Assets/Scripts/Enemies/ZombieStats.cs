using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;

    //Aktuelle Stats
    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <=0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //Reference script from collided collider and deal damag using take dmg
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();  
            player.TakeDamage(currentDamage); //current dmg in case of multipliers
        }
    }
}
