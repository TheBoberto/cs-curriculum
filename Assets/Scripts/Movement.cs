using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float xdirection;
    public float ydirection;
    public float yvelocity;
    public float xvelocity;
    public float walkingspeed;
    public float basespeed;
    public float speedmultiplier;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        xdirection = 0;
        ydirection = 0;
        xvelocity = 0;
        yvelocity = 0;
        basespeed = 8;
        walkingspeed = 0;
        speedmultiplier = 1;
        pc = this.gameObject.GetComponent<PlayerController>();
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
        if (pc.overworld)
        {
            yvelocity = ydirection * walkingspeed;
        }
        transform.Translate(xvelocity * Time.deltaTime, yvelocity * Time.deltaTime, 0);
    }
}
