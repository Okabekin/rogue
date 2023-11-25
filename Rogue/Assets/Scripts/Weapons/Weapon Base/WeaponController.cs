using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;


//base script for all weapons

public class WeaponController : MonoBehaviour
{

    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    protected PlayerMovement pm;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindAnyObjectByType<PlayerMovement>();
        currentCooldown = cooldownDuration; //At the start set cooldown (dont attack immediately)
    }

    // Update is called once per frame
   protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f)   //Attack when cd becomes 0
        {
            Attack();
        }
    }

   protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }






}
