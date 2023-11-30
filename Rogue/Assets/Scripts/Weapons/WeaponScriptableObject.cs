using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponScriptableObject", menuName ="ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    //Basiswerte fuer Waffen
    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }

    


    [SerializeField]
    float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }

    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }

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
