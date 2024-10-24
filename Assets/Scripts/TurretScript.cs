using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private float timer;
    public GameObject bullet;
    public bool balls;
    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        balls = true;
        if (balls) ;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Collider2D[] targets =
            Physics2D.OverlapCircleAll(new Vector3(transform.position.x, transform.position.y, 0), 5);
        foreach (var other in targets)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //pop a cap in his ass
                if (timer <= 0)
                {
                    GameObject obj = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y,0), new Quaternion(0,0,0,0));
                    obj.GetComponent<BulletScript>().TargetLocation = other.transform.position;
                    timer = 2;
                }
            }
            
        }
        
        
    }
    
}
