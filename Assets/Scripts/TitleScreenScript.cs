using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //enter the game screen
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }

        //exit the game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
