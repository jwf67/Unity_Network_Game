using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class EntityHealth : NetworkBehaviour {

    //maximum health of the entity
    public static int maxHealth = CONSTANTS.MAX_HEALTH;

    //health of the entity
    [SyncVar(hook = "OnChangeHealth")]
    public int health = maxHealth;

    //health bar
    public RectTransform healthBar;

    public Text healthText;

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
            Destroy(this.gameObject);
        }
    }

    //heal
    public void restoreHealth(int amount)
    {
        health += amount;


        if (health >= maxHealth)
        {
            health = maxHealth;
            Debug.Log("Fully restored");
        }
    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    private int count;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player_bullet")
        {
            Destroy(other.gameObject);
            takeDamage(10);
            SetHealthText();
        }
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "You Lose :( Press ESC to Quit";
        }
    }
}
