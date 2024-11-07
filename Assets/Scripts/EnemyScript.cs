using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject wp0;
    public GameObject wp1;
    public GameObject wp2;
    public GameObject wp3;
    public GameObject wp4;
    private int targetwp;
    public GameManager gm;
    private Vector3 targetlocation;
    private bool continuechase;
    private float speed;
    private statelist state;
    private float attacktimer;
    private float attackcooldown;
    public Collection cl;
    public bool isattacking;
    private float playerdistance;
    public Animator EnemyAnimator;
    public int health;
    public GameObject Axe;
    public PlayerController pc;
    enum statelist
    {
        patrol,
        chase,
        attack,
        die
    }
    // Start is called before the first frame update
    void Start()
    {
        targetwp = 0;
        speed = 3;
        targetlocation = new Vector3(wp0.transform.position.x,wp0.transform.position.y,0);
        continuechase = false;
        changestate(statelist.patrol);
        attackcooldown = 0;
        playerdistance = 999;
        health = 3;
    }
    
    void changehealth(int amount)
    {
        health += amount;
        if (health < 1)
        {
            health = 0;
            changestate(statelist.die);
        }
    }
    void OnCollisionEnter2D(Collision2D bonk)
    {
        if (bonk.gameObject.CompareTag("Player")) // && gm.PlayerIsAttacking == true)
        {
            Debug.Log("Enemy takes damage");
            changehealth(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackcooldown -= Time.deltaTime;
        if (state == statelist.attack)
        {
            attacktimer -= Time.deltaTime;
            if (attacktimer < 0 || Vector3.Distance(transform.position, targetlocation) < 0.2f)
            {
                changestate(statelist.chase);
                isattacking = false;
                attackcooldown = 2;
                targetlocation.x = transform.position.x + 999;
                targetlocation.y = transform.position.y + 999;
            }
        }
        
        if (state == statelist.chase)
        {
            playerdistance = 999;
            continuechase = false;
            Collider2D[] targets =
                Physics2D.OverlapCircleAll(new Vector3(transform.position.x, transform.position.y, 0), 5);
            foreach (var other in targets)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    continuechase = true;
                    if (Vector3.Distance(transform.position, other.transform.position) <
                        playerdistance)
                    {
                        targetlocation = other.transform.position;
                        playerdistance = Vector3.Distance(transform.position, other.transform.position);
                    }
                }

            }
            
            if (continuechase == false)
            {
                changestate(statelist.patrol); 
                changewp(0);
            }
            
            Collider2D[] targets2 =
                Physics2D.OverlapCircleAll(new Vector3(transform.position.x, transform.position.y, 0), 2.5f);
            foreach (var other in targets2)
            {
                if (other.gameObject.CompareTag("Player") && attackcooldown < 0)
                {
                    changestate(statelist.attack);
                }
            }
        }
        
        if (state == statelist.die)
        {
            Instantiate(Axe, transform.position, quaternion.identity);
            Destroy(this.gameObject);
        }
        
        if (state == statelist.patrol)
        {
            Collider2D[] targets =
                Physics2D.OverlapCircleAll(new Vector3(transform.position.x, transform.position.y, 0), 3);
            foreach (var other in targets)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    changestate(statelist.chase);
                    targetlocation = other.transform.position;
                }

            }
            if (transform.position == targetlocation)
            {
                changewp(1);
            }
        }
        
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0), targetlocation,
            speed * Time.deltaTime);
    }

    private void changewp(int amount)
    {
        targetwp += amount;
        if (targetwp > 4)
        {
            targetwp = 0;
        }

        if (targetwp == 0)
        {
            targetlocation = new Vector3(wp0.transform.position.x,wp0.transform.position.y,0);
        }
        if (targetwp == 1)
        {
            targetlocation = new Vector3(wp1.transform.position.x,wp1.transform.position.y,0);
        }
        if (targetwp == 2)
        {
            targetlocation = new Vector3(wp2.transform.position.x,wp2.transform.position.y,0);
        }
        if (targetwp == 3)
        {
            targetlocation = new Vector3(wp3.transform.position.x,wp3.transform.position.y,0);
        }
        if (targetwp == 4)
        {
            targetlocation = new Vector3(wp4.transform.position.x,wp4.transform.position.y,0);
        }
    }

    void changestate(statelist setstate)
    {
        if (state != statelist.die)
        {
            state = setstate;
        }

        if (state == statelist.patrol)
        {
            speed = 3;
            playerdistance = 999;
        }

        if (state == statelist.chase)
        {
            speed = 4.75f;
            playerdistance = 999;
        }

        if (state == statelist.die)
        {
            speed = 0;
        }

        if (state == statelist.attack)
        {
            attacktimer = 1;
            isattacking = true;
            speed = 9;
            playerdistance = 999;
            float xdif;
            float ydif;
            float angle;
            Vector3 tp;
            tp = transform.position;
            xdif = targetlocation.x - tp.x;
            ydif = targetlocation.y - tp.y;
            angle = Mathf.Atan(ydif / xdif);
            if (xdif < 0)
            {
                targetlocation = new Vector3(tp.x - 3 * Mathf.Cos(angle), tp.y - 3 * Mathf.Sin(angle));
            }

            if (xdif >= 0)
            {
                targetlocation = new Vector3(tp.x + 3 * Mathf.Cos(angle), tp.y + 3 * Mathf.Sin(angle));
            }

            EnemyAnimator.Play("AttackDown");
        }
    }
}
