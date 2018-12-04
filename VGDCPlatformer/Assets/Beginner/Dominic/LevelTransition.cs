using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {
    public string location = "BrandonScene2";
	// Use this for initialization
	void Start () {
        Debug.Log("Started.");
	}
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene(location);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
