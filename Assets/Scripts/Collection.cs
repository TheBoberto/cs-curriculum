using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collection : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            gm.changeCoins(1);
            Destroy(collision.gameObject);
        }
    }
}
