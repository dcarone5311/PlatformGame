using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onTriggerEnter2D(Collider collider)
    {
        Debug.Log("Respawn point triggered.");
        player.transform.position = respawnPoint.transform.position;
    }

    void onCollisionEnter2D(Collider collider)
    {
        Debug.Log("Respawn point triggered. (Collision)");
        player.transform.position = respawnPoint.transform.position;
    }
}
