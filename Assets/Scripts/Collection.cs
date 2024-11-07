using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collection : MonoBehaviour
{
    public GameManager gm;
    public TopDown_AnimatorController tdac;
    public bool AxeEquipped;
    public bool AxeCollected;
    public float AxeCollectionTimer;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        tdac = FindObjectOfType<TopDown_AnimatorController>();
        AxeEquipped = false;
        AxeCollected = false;
        AxeCollectionTimer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            gm.changeCoins(1);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Axe"))
        {
            if (AxeCollectionTimer < 0)
            {
                tdac.SwitchToAxe();
                AxeEquipped = true;
                AxeCollected = true;
                Destroy(collision.gameObject);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (AxeCollected == false)
        {
            AxeCollectionTimer -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (AxeCollected == true)
            {
                if (AxeEquipped == false)
                {
                    AxeEquipped = true;
                    tdac.SwitchToAxe();
                }
                else
                {
                    AxeEquipped = false;
                    tdac.SwitchToShovel();
                }
            }
        }
    }
}