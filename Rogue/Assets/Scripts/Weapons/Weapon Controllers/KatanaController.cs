using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); 
    }

   protected override void Attack()
    {
        base.Attack();
        GameObject spawnedKatana = Instantiate(weaponData.Prefab);
        spawnedKatana.transform.position = transform.position; //Assign same position as parent
        spawnedKatana.GetComponent<KatanaBehaviour>().DirectionChecker(pm.lastMovedVector); //Reference and set direction
    }
}
