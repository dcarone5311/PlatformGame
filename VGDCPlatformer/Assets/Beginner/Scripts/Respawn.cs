using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    List<Checkpoint> respawnPoints = new List<Checkpoint>();
    public PlayerMovement player;
    private Transform playerTransform;

	// Use this for initialization
	void Awake () {
        playerTransform = player.gameObject.transform;
        for(int i =0; i < transform.childCount; i++) //dynamically get checkpoints that are children of the trigger
        {
            Checkpoint childCheckpoint = transform.GetChild(i).GetComponent<Checkpoint>(); // this object's transform > child > its component that is a checkpoint
            Debug.Log(childCheckpoint.checkpointNum);
            respawnPoints.Add(childCheckpoint);
        }
	}

    void Start()
    {
    }

    // Update is called once per frame
    void Update () {
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Respawn point triggered.");
        Debug.Log(player.checkpoint);
        Debug.Log(respawnPoints[player.checkpoint]);
        playerTransform.transform.rotation = Quaternion.identity; //need to get transform component first in order to change its properties
        playerTransform.transform.position = respawnPoints[player.checkpoint].gameObject.transform.position;

    }



}
