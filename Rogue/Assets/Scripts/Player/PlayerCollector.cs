using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats Player;
    CircleCollider2D playerCollector;
    public float pullSpeed;

    void Start()
    {
        Player = FindObjectOfType<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        playerCollector.radius = Player.currentMagnet;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Check if the other game object has ICollectible interface
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            //Magnet Animation
            //Gets the Rigidbody2D component on the item
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            //Vector that points the item towards the player
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            //This adds the force that will pull the item towards the player
            rb.AddForce(forceDirection * pullSpeed);

            //If it does calll collect method
            collectible.Collect();
        }
    }
}
