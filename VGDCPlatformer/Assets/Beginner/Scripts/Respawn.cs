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

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Respawn point triggered.");
        player.transform.rotation = Quaternion.identity;
        //player.transform.Rotate(Vector3.up, 360 - Mathf.Abs(player.transform.rotation.z));
        player.transform.position = respawnPoint.transform.position;
    }

        

}
