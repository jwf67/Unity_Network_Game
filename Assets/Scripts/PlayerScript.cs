using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerScript : NetworkBehaviour {

    //player's speed
    public float speed = CONSTANTS.PLAYER_SPEED;

    //player's rotational speed
    public float rSpeed = CONSTANTS.PLAYER_ROTATION_SPEED;

    //bullet instantiation
    public GameObject bullet;
    public Transform bulletSpawn;

    //bullet speed
    public float bulletSpeed = CONSTANTS.BULLET_SPEED;

    //how long a bullet lasts in the world
    public float bulletLifetime = CONSTANTS.BULLET_LIFETIME;

    //transform position
    Vector3 transformPosition;

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

        //local player controls arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime; 
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.C))
        {
            this.transform.Rotate(0, 0, rSpeed);
        }
        if (Input.GetKey(KeyCode.V))
        {
            this.transform.Rotate(0, 0, -rSpeed);
        }
        //shoot object in direction of character with spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            CmdShootBullet();
        }
    }

    //shoot bullet on network
    [Command]
    void CmdShootBullet()
    {
        //Create a new bullet instance
        var bulletInstance = (GameObject) Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        //bullet will travel forward based on current transform position and rotation
        bulletInstance.GetComponent<Rigidbody>().velocity = bulletInstance.transform.up * bulletSpeed;

        //Bullet spawns on clients
        NetworkServer.Spawn(bulletInstance);

        //Bullet is deleted after 2 seconds
        Destroy(bulletInstance, bulletLifetime);
    }

    //make the player's recognizable from the others
    public override void OnStartLocalPlayer()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 1f);
    }
}
