using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Edited by Dominic Carone

public class PlayerMovementBeginner : MonoBehaviour {

    public Rigidbody2D m_RigidBody2D;

    [Header("Movement Logic")]
    //=========== Moving Logic ============
    public float runSpeed = 0f;
    private float horizontalMove = 0f;
    private Vector3 m_Velocity = Vector3.zero;

    [Space]
    [Header("Jump Logic")]

    //============ Jump Logic ============
    public float m_JumpForce = 200f;
    private bool m_Grounded = false;
    public Transform m_GroundCheck;
    public LayerMask m_GroundLayer = 0;


    // Use this for initialization
    void Start()
    {
        //m_RigidBody2D = GetComponent<Rigidbody2D>(); //Instead of manually putting the RigidBody2D Component we can get the component from the Object

        m_Velocity = Vector3.zero; //same as new Vector3(0,0,0)
        m_GroundCheck = GameObject.Find("PLATFORM").transform;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (m_Grounded && Input.GetButtonDown("Jump")) //If the player is on ground and pressing Jump
        {
            m_Grounded = false; //player is no longer grounded and experiences an immediate upward force
            m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
        }
    }

    // FixedUpdate is called multiple times per frame at different rates
    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f * Time.fixedDeltaTime, m_RigidBody2D.velocity.y);
        m_RigidBody2D.velocity = targetVelocity;
        if (m_RigidBody2D.velocity == new Vector2(0.0f,0.0f) )
        {
           //play idle animation
            
        }
        if (this.gameObject.transform.rotation.y == 0.0f && m_RigidBody2D.velocity.x < 0)
        {
            this.gameObject.transform.rotation =  new Quaternion(0.0f,180.0f,0.0f,0.0f);
        }
        if (this.gameObject.transform.rotation.y != 0.0f && m_RigidBody2D.velocity.x > 0)
        {
            this.gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
        
       

        m_Grounded = Physics2D.Linecast(this.gameObject.transform.position, m_GroundCheck.position, m_GroundLayer); //true if player contacts ground
        if (m_Grounded)
        {
            Debug.Log("Grounded.");
        }
    }
}
