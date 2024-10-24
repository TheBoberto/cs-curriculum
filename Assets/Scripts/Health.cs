using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gm.changeHealth(-1);
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            gm.changeHealth(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            gm.changeHealth(-2);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            gm.changeHealth(-3);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript ScriptOfEnemy = collision.gameObject.GetComponent<EnemyScript>();
            if (ScriptOfEnemy.isattacking)
            {
                gm.changeHealth(-3);
            }
        }
    }
}
