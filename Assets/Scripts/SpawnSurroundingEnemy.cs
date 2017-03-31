using UnityEngine;
using System.Collections;

public class SpawnSurroundingEnemy : MonoBehaviour {

    //bullet instantiation
    public Rigidbody2D enemy;

    //distance from player when spawning
    public float distance = 10.0f;

    //keep track of enemies spawned
    private float enemyCount = 0.0f;

    //Spawn Rate - how long does it take for another enemy to spawn
    public float spawn = 1;
    //Timer
    private float timer;
    // Use this for initialization
    void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time > timer + spawn)
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
        Rigidbody2D enemyInstance = Instantiate(enemy, enemyPosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        enemyInstance.velocity = new Vector2(0, 0);
        //direction the bullet is going to travel
        Vector2 targetDirection = new Vector2(targetPosition.x, targetPosition.y);

        //set the bullet instance's direction its actual path
        //enemyInstance.velocity = targetDirection;
    }

    float[] GenerateRandomPosition()
    {
        //x is at index 0, y is at index 1
        float[] x_and_y = new float[2];
        Random rand = new Random();

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

        Debug.Log(y);

        return x_and_y;
    }
}
