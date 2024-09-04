using System.Collections;
using System.Collections.Generic;
using UnityEngine;
Rigidbody2D rb;

public class Movement : MonoBehaviour
{
    public float xdirection;
    public float ydirection;
    public float yvelocity;
    public float xvelocity;
    public float walkingspeed;
    public bool overworld;
    // Start is called before the first frame update
    void Start()
    {
        xdirection = 0;
        ydirection = 0;
        xvelocity = 0;
        yvelocity = 0;
        walkingspeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        xdirection = Input.GetAxis("Horizontal");
        ydirection = Input.GetAxis("Vertical");
        xvelocity = xdirection * walkingspeed;
        if (overworld == true)
        {
            yvelocity = xdirection * walkingspeed;
        }
        transform.Translate(xvelocity, yvelocity, 0);
    }
}
