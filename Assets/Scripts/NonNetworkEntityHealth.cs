using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NonNetworkEntityHealth : MonoBehaviour
{

    //maximum health of the entity
    public const int MAX_HEALTH = CONSTANTS.MAX_HEALTH;

    //health of the entity
    public int health = MAX_HEALTH;

    //health bar
    //public RectTransform healthBar;


    public Text healthText;

    // Update is called once per frame
    void Update()
    {

    }

    //take damage
    public void takeDamage(int amount)
    {
        health -= amount;
        OnChangeHealth(health);
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
        OnChangeHealth(health);

        if (health >= MAX_HEALTH)
        {
            health = MAX_HEALTH;
            Debug.Log("Fully restored");
        }
    }

    void OnChangeHealth(int health)
    {
        //healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    private int count;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            health -= 10;
            SetHealthText();
        }
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            Time.timeScale = 0;
            healthText.text = "You Lose :( Press ESC to Quit";
        }
    }
}
