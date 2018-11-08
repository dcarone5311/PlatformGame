using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    public Transform cameraTransform;
    private Vector2 cameraPosition;
    public float followWidth, followHeight;
    private float cameraSize;//creates a frame the camera will follow the player if they are on the edge of this frame.
  
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        cameraTransform = GetComponent<Transform>();
        //ameraSize = GetComponent<Camera.>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        cameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraPosition.x-player.transform.position.x) > followWidth || Mathf.Abs(cameraPosition.y - player.transform.position.y) > followHeight)
        {
            cameraTransform.position = new Vector3(Mathf.Clamp(cameraPosition.x, player.transform.position.x - (followWidth / 2), player.transform.position.x + (followWidth / 2)), 
                Mathf.Clamp(cameraPosition.y, player.transform.position.y - (followHeight / 2), player.transform.position.y + (followHeight / 2)), cameraTransform.position.z);
            
        }
    }
}
