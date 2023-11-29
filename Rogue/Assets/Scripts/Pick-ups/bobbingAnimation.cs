using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingAnimation : MonoBehaviour


{

    public float frequency; //speed
    public float magnitude; //range
    public Vector3 direction; //direction
    Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        //save starting position
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initialPosition + direction * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
