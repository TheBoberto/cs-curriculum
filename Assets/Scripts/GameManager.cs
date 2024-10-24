using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private int coins;
    private int health;
    private int maxHealth;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI HealthText; 
    void Awake()
    {
        if (gm != null && gm != this) 
        {
            //commit suicide like a damn loser
            Destroy(this.gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
            coins = 0;
            health = 10;
            maxHealth = 10; 
            
            HealthText.text = "Health: " + health;
            CoinText.text = "Coins: " + coins;
        }
    }

    public int getHealth()
    {
        return health;
    }

    public void changeHealth(int amount)
    {
        health += amount;
        
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health < 1)
        {
            health = 0;
            Die();
        }

        HealthText.text = "Health: " + health;
    }
    
    public void changeCoins(int amount)
    {
        coins += amount;
        
        if (coins < 0)
        {
           print("lmao ur in debt");
        }

        CoinText.text = "Coins: " + coins;
    }

    void Die()
    {
        print("You got cooked loser");
        health = 10;
        maxHealth = 10;
        HealthText.text = "Health: " + health;
        SceneManager.LoadScene(0);
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
}
