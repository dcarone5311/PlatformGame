using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercoin : MonoBehaviour
{

    private coincount coincount1;

    private bool hasCollide = false;

    // Use this for initialization
    void Start()
    {
        coincount1 = GameObject.FindWithTag("coincount").GetComponent<coincount>();
    }

    // Update is called once per frame
    void Update()
    {
        hasCollide = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {
            if (hasCollide == false)
            {
                hasCollide = true;
                Destroy(col.gameObject);
                coincount1.coins += 1;
            }
        }
    }
}