﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
    List<Checkpoint> respawnPoints = new List<Checkpoint>();
    public PlayerMovement player;
    private Transform playerTransform;

    public int lives = 3;
    public Text livesText;

    public delegate void deatherino();
    public static event deatherino OnPlayerDeath;

    
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
        OnPlayerDeath += respawn;
    }

    private void OnDisable() //this is to prevent memory leaks
    {
        OnPlayerDeath -= respawn;
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
        Debug.Log("Player checkpoint at: " + player.checkpoint); 
        Debug.Log(respawnPoints[player.checkpoint]);

        playerDeath();
    }

    public static void playerDeath()
    {
        OnPlayerDeath();
    }

    // reloads the level
    void gameOver()
    {
            Application.LoadLevel(Application.loadedLevel);
    }

    void respawn()
    {
        Debug.Log("Respawning");
        playerTransform.transform.rotation = Quaternion.identity; //identity = rotation 0 0 0
        playerTransform.transform.position = respawnPoints[player.checkpoint].gameObject.transform.position;

        lives -= 1;

        if (lives <= 0)
        {
            gameOver();
        }


    }


}
