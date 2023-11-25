using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//base script for melee behavior (place on prefab of melee weapon
public class MeleeWeaponBehaviour : MonoBehaviour
{

    public float destroyAfterSeconds;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    
}
