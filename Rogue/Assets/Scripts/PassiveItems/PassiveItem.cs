using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{

    protected PlayerStats player;
    public PassiveItemScribtableObject passiveItemData;

    protected virtual void ApplyModifier()
    {
        //Apply boost to approrpiate stat
    }


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        ApplyModifier();
    }

  
}
