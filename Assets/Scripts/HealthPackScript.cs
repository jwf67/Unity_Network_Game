using UnityEngine;
using System.Collections;

public class HealthPackScript : MonoBehaviour {

    //heal amount
    public int healAmt = 20;

    //timer to delete health packs
    public float timer;

    //time until it despawns
    public float timeActive = 10.0f;

    // Use this for initialization
    void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timer + timeActive)
        {
            DestroyObject(gameObject);
            timer = Time.time;
        }
    }

    //If collides with a entity with health give it health
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<EntityHealth>();

        if (health != null)
        {
            health.restoreHealth(healAmt);
        }

        DestroyObject(gameObject);

    }
}
