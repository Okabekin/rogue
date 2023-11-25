using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{

    Transform Player;
    public float moveSpeed;
    public Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
    }
}