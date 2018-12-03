
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public bool hurtbox = false;
   
    //Use this for initialization
    void Start()
    {
      
    }


    //will occur when player interacts with Enemy object
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "hurtbox")
        {
            //to kill enemy, we tell the enemy script
            hurtbox = true;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1100);
            TheEnemy script = collide.gameObject.GetComponentInParent<TheEnemy>();
            script.Die();
        }

        if (collide.gameObject.tag == "hitbox")
        {
            Respawn.playerDeath();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
