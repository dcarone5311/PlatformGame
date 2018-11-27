using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Started.");
	}
    void OnTriggerEnter2D ()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
