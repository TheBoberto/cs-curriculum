using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPositionScript : MonoBehaviour
{
    private Vector3 location;
    // Start is called before the first frame update
    void Start()
    {
        location = new Vector3(transform.position.x,transform.position.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = location;
    }
}
