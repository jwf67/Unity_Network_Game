using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    //damage the bullet deals
    public int damage = 5;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<EntityHealth>();

        if(health != null)
        {
            health.takeDamage(damage);
        }

        DestroyObject(gameObject);

    }

    //when the bullet is invisible destroy it
    void OnBecameInvisible()
    {
        DestroyObject(gameObject);
    }
}
