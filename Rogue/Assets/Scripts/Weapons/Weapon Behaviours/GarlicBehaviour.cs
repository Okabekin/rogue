using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> markedEnemies;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
        {
            ZombieStats enemy = col.GetComponent<ZombieStats>();
            enemy.TakeDamage(currentDamage);

            markedEnemies.Add(col.gameObject); //Gegner wird markiert und kann nicht mit diesem Garlic wieder beschaedigt werden
        }
        else if (col.CompareTag("Prop"))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable) && !markedEnemies.Contains(col.gameObject))
            {
                breakable.TakeDamage(currentDamage);
                
                markedEnemies.Add(col.gameObject) ;
            }
        }
    }

}
