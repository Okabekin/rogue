using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    ZombieStats enemy;
    Transform Player;
    public Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<ZombieStats>();
        Player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);
    }
}