using UnityEngine;
using System.Collections;

public class SpawnSurroundingHealth : MonoBehaviour {

    //health pack instantiation
    public Rigidbody2D health_pack;

    //distance from player when spawning
    public float distance = 10.0f;

    //Spawn Rate - how long does it take for another health pack to spawn
    public float spawnRate = 1;

    //Timer
    private float timer;

    // Use this for initialization
    void Start()
    {
        timer = Time.time;

    }
   
	
	// Update is called once per frame
	void Update () {

        if (Time.time > timer + spawnRate)
        {
            SpawnHealthPack();
            timer = Time.time;
        }
    }

    public void SpawnHealthPack()
    {
        //store position of the object
        float[] object_xy = ObjectSpawnUtility.GenerateRandomPosition(distance);

        //Get the position of the player
        Vector3 targetPosition = transform.position;
        targetPosition.z = 0.0f;

        //initialize position of the enemy
        Vector3 objectPosition = new Vector3(object_xy[0], object_xy[1], 0.0f);

        //Create a new enemy instance
        Rigidbody2D objectInstance = Instantiate(health_pack, objectPosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        objectInstance.velocity = new Vector2(0, 0);
        //direction of travel 
        Vector2 targetDirection = new Vector2(targetPosition.x, targetPosition.y);

    }
}
