using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegner_AI : MonoBehaviour
{
    Transform Test_Spielfigur;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        Test_Spielfigur = FindObjectOfType<Test_Bewegung_Spielfigur>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Test_Spielfigur.transform.position, movespeed * Time.deltaTime);
    }
}
