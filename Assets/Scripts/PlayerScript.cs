using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerScript : NetworkBehaviour {

    //speed of the bullet
    public float speed = 2.0f;

    //bullet instantiation
    public GameObject bullet;
    public Transform bulletSpawn;

    //bullet speed
    public float bulletSpeed = 4.0f;

    //var distance
    public float distance = 5.0f;

    //keep track of bullets shot
    private float shotsFired = 0.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //only the local player should be controlled
        if (!isLocalPlayer)
        {
            return;
        }

        //control Roggenbrot with W, A, S, and D
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime; 
        }
        if(Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //shoot object in direction of mouse
        if (Input.GetMouseButtonDown(0))
        {
            //shoot the bullet
            CmdShootBullet();
        }
    }

    //shoot bullet on network
    [Command]
    void CmdShootBullet()
    {
        //shots fired += 1
        shotsFired += 1;

        //initialize mouse position on screen
        Vector3 mousePosition = Input.mousePosition;

        //make sure the mouse z position is 0. deal with x and y only
        mousePosition.z = 0.0f;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //get the difference of the mouse position and the current object to create a vector
        mousePosition = mousePosition - transform.position;

        //Create a new bullet instance
        var bulletInstance = (GameObject) Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        //direction the bullet is going to travel
        Vector2 bulletDirection = new Vector2(mousePosition.x * speed, mousePosition.y * speed);

        Debug.Log("RMS");
        Debug.Log(mousePosition.x);
        Debug.Log(speed);

        //set the bullet instance's direction its actual path
        bulletInstance.GetComponent<Rigidbody2D>().velocity = bulletDirection;

        //Bullet spawns on clients
        NetworkServer.Spawn(bulletInstance);

        //Bullet is deleted after 2 seconds
        Destroy(bulletInstance, 2.0f);
    }

    //make the player's recognizable from the others
    public override void OnStartLocalPlayer()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 1f);
    }
}
