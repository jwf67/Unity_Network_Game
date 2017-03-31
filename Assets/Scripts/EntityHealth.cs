using UnityEngine;
using System.Collections;

public class EntityHealth : MonoBehaviour {

    //maximum health of the entity
    public const int MAX_HEALTH = 50;

    //health of the entity
    public int health = MAX_HEALTH;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    //take damage
    public void takeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            health = 0;
            Debug.Log("object reached <= 0 health");
        }
    }

    //heal
    public void restoreHealth(int amount)
    {
        health += amount;

        if(health >= MAX_HEALTH)
        {
            health = MAX_HEALTH;
            Debug.Log("Fully restored");
        }
    }
}
