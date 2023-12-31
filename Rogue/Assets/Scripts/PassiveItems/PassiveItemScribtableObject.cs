using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName ="ScriptableObjects/PassiveItem")]
public class PassiveItemScribtableObject : ScriptableObject
{
    [SerializeField]
    float multiplier;
    public float Multiplier { get => multiplier; private set => multiplier = value; }
    // Start is called before the first frame update

    [SerializeField]
    int level; //not meant to be modified ingame
    public int Level { get => level; private set => level = value; }

    [SerializeField]
    GameObject nextLevelPrefab; //prefab of next level (what object becomes when it levels up
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }

    [SerializeField]
    public string name;
    public string Name { get => name; private set => name = value; }

    [SerializeField]
    string description; // what is the description of this weapon, if it is an upgrade place description of the upgrades
    public string Description { get => description; private set => description = value; }


    [SerializeField]
    Sprite icon; //not meant to be modified in game only in editor
    public Sprite Icon { get => icon; private set => icon = value; }
}
