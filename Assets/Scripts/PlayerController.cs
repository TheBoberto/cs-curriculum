using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gm;
    public bool overworld;
    public Collection cl;
    public bool DoorAttackable;
    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?
        DoorAttackable = false;
        
        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            DoorAttackable = true;
            if (DoorAttackable == true && cl.AxeEquipped == true && gm.PlayerIsAttacking == true)
            {
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D exiting)
    {
        if (exiting.gameObject.CompareTag("Door"))
        {
            DoorAttackable = false;
        }
    }
    
    
    private void Update()
    {
        
    }
    
    //for organization, put other built-in Unity functions here
    
    
    
    
    
    //after all Unity functions, your own functions can go here
}