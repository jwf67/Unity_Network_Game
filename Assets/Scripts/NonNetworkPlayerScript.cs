using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NonNetworkPlayerScript : MonoBehaviour
{
    //player's speed
    public float speed = CONSTANTS.PLAYER_SPEED;

    //bullet instantiation
    public GameObject bullet;
    public Transform bulletSpawn;

    //bullet speed
    public float bulletSpeed = CONSTANTS.BULLET_SPEED;

    //transform position
    Vector3 transformPosition;

    // Use this for initialization
    void Start()
    {
        Debug.Log("START GAME");
    }

    // Update is called once per frame
    void Update()
    {
        //local player controls arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
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
            this.transform.Rotate(0, 0, 2.5f);
            Debug.Log("ROTATEA");
        }
        if (Input.GetKey(KeyCode.V))
        {
            this.transform.Rotate(0, 0, -2.5f);
            Debug.Log("ROTATEB");
        }
        //shoot object in direction of character with spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            shootBullet();
        }
    }

    //shoot bullet off network
    void shootBullet()
    {
        //Create a new bullet instance
        var bulletInstance = (GameObject)Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        //bullet will travel forward based on current transform position and rotation
        bulletInstance.GetComponent<Rigidbody>().velocity = bulletInstance.transform.up * bulletSpeed;

        //Bullet is deleted after 2 seconds
        Destroy(bulletInstance, 2.0f);
    }
}
