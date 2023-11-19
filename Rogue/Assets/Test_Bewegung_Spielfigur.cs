using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Bewegung_Spielfigur : MonoBehaviour
{
    public Rigidbody2D Spielfigur;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        { 
            Spielfigur.velocity = Vector2.up * 10;
        }

        
    }
}
