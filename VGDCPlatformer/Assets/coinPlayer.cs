using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPlayer : MonoBehaviour {

    private coincount coincount;

	// Use this for initialization
	void Start ()
    {
        coincount = GameObject.FindWithTag("coincount").GetComponent<coincount>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("coin"))
        {
            Destroy(col.gameObject);
            coincount.coins += 1;
        }
    }
}
