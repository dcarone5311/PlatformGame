using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//player movement- Dominic Carone
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D m_RigidBody2D;

    [Header("Movement Logic")]
    //=========== Moving Logic ============
    public float runSpeed = 50f; //running speed is max speed on ground with no external forces
    public float dashSpeed = 80.0f; // speed when holding the dash button
    private float horizontalMove = 0f; //current horizontal component velocity
    private Vector3 m_Velocity;
    [Space]
    [Header("Jump Logic")]

    //============ Jump Logic ============
    //public float m_JumpForce = 200f;
    public float jumpSpeed = 80f; //use a jump speed instead of jump force to prevent double jump from adding up
    private bool m_Grounded, m_WalledLeft, m_WalledRight;
    public Transform m_GroundCheck, m_WallCheckLeft, m_WallCheckRight;
    public LayerMask m_GroundLayer, m_WallLayer;
    private float verticalMove = 0f;
    public int midAirJumps; //set to 1 for double jump, 2 for triple.
    private int jumpCount;

    // Use this for initialization

    void Start()

    {

        //m_RigidBody2D = GetComponent<Rigidbody2D>(); //Instead of manually putting the RigidBody2D Component we can get the component from the Object
        m_Velocity = Vector3.zero; //same as new Vector3(0,0,0) ; initialize the player to stationary

    }

    // Update is called once per frame

    void Update()

    {
        if (m_WalledRight)
            Debug.Log("Walled right.");        
        if (Input.GetButton("Dash")) //if dashing,
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * dashSpeed; //increase horizontal speed 
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        if (m_Grounded ) //if on the ground 
        {
            jumpCount = midAirJumps;
            if (Input.GetButtonDown("Jump")) //jump button is pressed
            {
                m_Grounded = false;
                m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, jumpSpeed * 10f * Time.fixedDeltaTime); //jump
            }
        }
        else
        {
            if ( m_WalledRight && Input.GetAxisRaw("Horizontal") >0  && Input.GetButtonDown("Jump")) //wall jump from right
            {
                m_RigidBody2D.velocity = new Vector2(-runSpeed * 10f * Time.fixedDeltaTime, jumpSpeed * 5f * Time.fixedDeltaTime);
            }
            else if ( jumpCount != 0 && Input.GetButtonDown("Jump"))
            {
                m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, jumpSpeed * 10f * Time.fixedDeltaTime); //jump
                jumpCount -= 1; //subtract one from midair jump counter. (Might read as grounded from ground jump
            }
        }

        
    }
    // FixedUpdate is called multiple times per frame at different rates
    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f * Time.fixedDeltaTime, m_RigidBody2D.velocity.y); //remove effect of external forces after a while
        m_RigidBody2D.velocity = targetVelocity; //maintain the target velocity
        m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
        m_WalledLeft = Physics2D.Linecast(transform.position, m_WallCheckLeft.position, m_WallLayer) ;
        m_WalledRight = Physics2D.Linecast(transform.position, m_WallCheckRight.position, m_WallLayer);
        
    }

}