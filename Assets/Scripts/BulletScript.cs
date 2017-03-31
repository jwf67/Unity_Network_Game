using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "enemy")
        {
            DestroyObject(gameObject);
        }
    }

    //when the bullet is invisible destroy it
    void OnBecameInvisible()
    {
        DestroyObject(gameObject);
    }
}
