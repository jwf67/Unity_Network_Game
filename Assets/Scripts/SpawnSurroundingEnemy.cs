using UnityEngine;
using System.Collections;

public class SpawnSurroundingEnemy : MonoBehaviour {

    //enemy instantiation
    public Rigidbody enemy;

    //distance from player when spawning
    public float distance = 10.0f;

    //Spawn Rate - how long does it take for another enemy to spawn
    public float spawnRate = 1;

    //Timer
    private float timer;
    // Use this for initialization
    void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time > timer + spawnRate)
        {
            SpawnEnemy();
            timer = Time.time;
        }
    }

    //Spawn a new enemy in a surrounding area
    void SpawnEnemy()
    {
        //store position of the enemy
        float[] enemy_xy = GenerateRandomPosition();

        //Get the position of the player
        Vector3 targetPosition = transform.position;
        targetPosition.z = 0.0f;

        //initialize position of the enemy
        Vector3 enemyPosition = new Vector3(enemy_xy[0], enemy_xy[1], 0.0f);

        //Create a new enemy instance
        Rigidbody enemyInstance = Instantiate(enemy, enemyPosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody;
        enemyInstance.velocity = new Vector3(0, 0, 0);
    }

    float[] GenerateRandomPosition()
    {
        //x is at index 0, y is at index 1
        float[] x_and_y = new float[2];

        float x = Random.Range(-distance, distance);

        float dist2 = Mathf.Pow(distance, 2);
        float x2 = Mathf.Pow(x, 2);
        float y = Mathf.Sqrt(dist2 - x2);

        float b = Random.Range(0, 2);

        if(b < 1.0f)
        {
            y *= -1;
        }

        x_and_y[0] = x;
        x_and_y[1] = y;

        //Debug.Log(y);

        return x_and_y;
    }
}
