using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercoin : MonoBehaviour
{

    private coincount coincount1;

    // Use this for initialization
    void Start()
    {
        coincount1 = GameObject.FindWithTag("coincount").GetComponent<coincount>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {
            Destroy(col.gameObject);
            coincount1.coins += 1;
        }
    }
}