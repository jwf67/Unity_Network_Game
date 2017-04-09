using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Load Main Screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        //Load Single Player Mode
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene(1);
        }
        //Load Multiplayer Mode
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(2);
        }
	}
}
