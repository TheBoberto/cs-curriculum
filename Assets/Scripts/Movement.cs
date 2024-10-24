using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rigidbody2D rb;

public class Movement : MonoBehaviour
{
    public float xdirection;
    public float ydirection;
    public float yvelocity;
    public float xvelocity;
    public float walkingspeed;
    public bool overworld;
    public float basespeed;

    public float speedmultiplier;
    // Start is called before the first frame update
    void Start()
    {
        xdirection = 0;
        ydirection = 0;
        xvelocity = 0;
        yvelocity = 0;
        basespeed = 5;
        walkingspeed = 0;
        overworld = true;
        speedmultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        xdirection = Input.GetAxis("Horizontal");
        ydirection = Input.GetAxis("Vertical");
        if (xdirection != 0 && ydirection != 0)
        {
            walkingspeed = basespeed * speedmultiplier *Mathf.Sqrt(2) / 2;
        }
        else
        {
            walkingspeed = basespeed * speedmultiplier;
        }
        xvelocity = xdirection * walkingspeed;
        if (overworld == true)
        {
            yvelocity = ydirection * walkingspeed;
        }
        transform.Translate(xvelocity * Time.deltaTime, yvelocity * Time.deltaTime, 0);
    }
}
