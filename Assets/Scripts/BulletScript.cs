using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 TargetLocation;
    private float xdif;
    private float ydif;
    private float xchange;
    private float ychange;
    private float targetangle;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        xdif = -TargetLocation.x + transform.position.x;
        ydif = -TargetLocation.y + transform.position.y;
        targetangle = Mathf.Atan(ydif/xdif);
        xchange = Mathf.Cos(targetangle);
        ychange = Mathf.Sin(targetangle);
        if (xdif > 0)
        {
            ychange = -ychange;
            xchange = -xchange;
        }

        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((7 * xchange * Time.deltaTime), (7 * ychange * Time.deltaTime), 0);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
