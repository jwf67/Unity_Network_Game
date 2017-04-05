using UnityEngine;
using System.Collections;

public class ObjectSpawnUtility : MonoBehaviour {

    //object instantiation
    private Rigidbody2D object_any;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static float[] GenerateRandomPosition(float distance)
    {
        //x is at index 0, y is at index 1
        float[] x_and_y = new float[2];

        float x = Random.Range(-distance, distance);

        float dist2 = Mathf.Pow(distance, 2);
        float x2 = Mathf.Pow(x, 2);
        float y = Mathf.Sqrt(dist2 - x2);

        float b = Random.Range(0, 2);

        if (b < 1.0f)
        {
            y *= -1;
        }

        x_and_y[0] = x;
        x_and_y[1] = y;

        //Debug.Log(y);

        return x_and_y;
    }
}
