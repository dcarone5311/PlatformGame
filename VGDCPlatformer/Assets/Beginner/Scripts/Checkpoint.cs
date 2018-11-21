using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public PlayerMovement player;
    bool passed;
    public int checkpointNum; // 0 = respawn, 1 = first checkpoint
	// Use this for initialization
	void Start () {
        passed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        passed = true;
        player.checkpoint = checkpointNum;
    }
}
