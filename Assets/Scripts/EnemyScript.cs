using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    //speed variable
    public float speed = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float thisX = this.transform.position.x;
        float thisY = this.transform.position.y;

        Vector3 targetPosition = GameObject.FindGameObjectWithTag("player").transform.position;

        float tarX = targetPosition.x;
        float tarY = targetPosition.y;

        int dirX = GetMovementDirection(tarX, thisX);
        int dirY = GetMovementDirection(tarY, thisY);
        
    
        transform.Translate(new Vector3(dirX * speed, dirY * speed, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player_bullet")
        {
            DestroyObject(gameObject);
        } else if (other.gameObject.tag == "player")
        {
            //other.gameObject.GetComponent<NonNetworkEntityHealth>().health -= 10;
            Debug.Log("collision with player");
        }
    }

    //using the numbers passed in get the positive or negative direction of travel
    int GetMovementDirection(float a, float b)
    {
        if (a > b)
            return 1;
        else if (a < b)
            return -1;
        else
            return 0;
    }

}
