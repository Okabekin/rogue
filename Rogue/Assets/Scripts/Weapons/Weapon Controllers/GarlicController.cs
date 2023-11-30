using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GarlicController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedGarlic = Instantiate(weaponData.Prefab);
        
        spawnedGarlic.transform.position = transform.position; // assign position to be same as this object which isp arented to player
        spawnedGarlic.transform.parent = transform; //spawns below this object
        
    }
}
