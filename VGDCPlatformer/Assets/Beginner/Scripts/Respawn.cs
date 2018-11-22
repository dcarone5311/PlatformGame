using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private int lives;
    public Text livesText;
    

	// Use this for initialization
	void Start ()
    {
        lives = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        livesText.text = ("Lives: " + lives);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Respawn point triggered.");
        player.transform.rotation = Quaternion.identity;
        //player.transform.Rotate(Vector3.up, 360 - Mathf.Abs(player.transform.rotation.z));
        player.transform.position = respawnPoint.transform.position;
        lives -= 1;
        if (lives <= 0)
        {
            gameOver();
        }
    }

    // reloads the level
    void gameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

        

}
