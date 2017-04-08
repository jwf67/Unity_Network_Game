using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class EntityHealth : NetworkBehaviour {

    //maximum health of the entity
    public const int MAX_HEALTH = 50;

    //health of the entity
    [SyncVar(hook = "OnChangeHealth")]
    public int health = MAX_HEALTH;

    //health bar
    public RectTransform healthBar;

    // Update is called once per frame
    void Update () {

    }

    //take damage
    public void takeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        health -= amount;

        //Debug.Log("Health: " + health);

        if (health <= 0)
        {
            health = 0;
            Debug.Log("object reached <= 0 health");
            //Destroy(gameObject);
        }
    }

    //heal
    public void restoreHealth(int amount)
    {
        health += amount;


        if (health >= MAX_HEALTH)
        {
            health = MAX_HEALTH;
            Debug.Log("Fully restored");
        }
    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}
