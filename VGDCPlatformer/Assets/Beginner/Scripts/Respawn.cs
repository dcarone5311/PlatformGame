using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
    List<Checkpoint> respawnPoints = new List<Checkpoint>();
    public PlayerMovement player;
    private Transform playerTransform;

    private int lives;
    public Text livesText;

    public delegate void deatherino();
    public static event deatherino OnDeath;

    
    void Start()
    {
        lives = 3;
        playerTransform = player.gameObject.transform;
        for (int i = 0; i < transform.childCount; i++) //dynamically get checkpoints that are children of the trigger
        {
            Checkpoint childCheckpoint = transform.GetChild(i).GetComponent<Checkpoint>(); // this object's transform > child > its component that is a checkpoint
            Debug.Log(childCheckpoint.checkpointNum);
            respawnPoints.Add(childCheckpoint);
        }
    }

    private void OnEnable()
    {
        OnDeath += respawn;
    }

    private void OnDisable() //this is to prevent memory leaks
    {
        OnDeath -= respawn;
    }
    // Use this for initialization
    void Awake () {

	}


    // Update is called once per frame
    void Update()
    {
        livesText.text = ("Lives: " + lives);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Respawn point triggered.");
        Debug.Log(player.checkpoint);
        Debug.Log(respawnPoints[player.checkpoint]);

        OnDeath();

    }

    // reloads the level
    void gameOver()
    {
            Application.LoadLevel(Application.loadedLevel);
    }

    void respawn()
    {
        playerTransform.transform.rotation = Quaternion.identity; //need to get transform component first in order to change its properties
        playerTransform.transform.position = respawnPoints[player.checkpoint].gameObject.transform.position;

        lives -= 1;

        if (lives <= 0)
        {
            gameOver();
        }


    }


}
