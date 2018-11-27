using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//player movement- Dominic Carone
public class PlayerMovement : MonoBehaviour
{
    public int checkpoint = 0; //0 is original spawn point
    public Rigidbody2D m_RigidBody2D;

    [Header("Movement Logic")]
    //=========== Moving Logic ============
    public float runSpeed = 8f; //running speed is max speed on ground with no external forces
    public float dashSpeed = 16f; // max speed when holding the dash button
    public float runForce = 30.0f; //acceleration to begin running
    private Vector3 m_Velocity; //player's velocity vector

    [Space]
    [Header("Jump Logic")]

    //============ Jump Logic ============
    //public float m_JumpForce = 200f;
    public float jumpSpeed = 80f; //use a jump speed instead of jump force to prevent double jump from adding up
    private bool m_Grounded, m_WalledLeft, m_WalledRight; //check if player is on ground or hugging wall
    public Transform m_GroundCheck, m_WallCheckLeft, m_WallCheckRight;
    public LayerMask m_GroundLayer, m_WallLayer;
    public int midAirJumps; //set to 1 for double jump, 2 for triple.
    private int jumpCount; //use to track how many jumps the player has left

    // Use this for initialization

    void Start()

    {

        //m_RigidBody2D = GetComponent<Rigidbody2D>(); //Instead of manually putting the RigidBody2D Component we can get the component from the Object
        m_Velocity = Vector3.zero; //same as new Vector3(0,0,0) ; initialize the player to stationary

    }

    // Update is called once per frame

    void Update()

    {
        //WALKING
        if (Input.GetButton("Horizontal"))
            {
                m_RigidBody2D.AddForce(new Vector2(Input.GetAxisRaw("Horizontal")*runForce, 0f)); //add a force to walk
            }
        
       
        //JUMPING
        if (m_Grounded ) //if on the ground 
        {
            jumpCount = midAirJumps;
            if (Input.GetButtonDown("Jump")) //jump button is pressed
            {
                m_Grounded = false;  //no longer grounded
                m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, jumpSpeed * 10f * Time.fixedDeltaTime); //jump
            }
        }
        else
        {
            if ( m_WalledRight && Input.GetAxisRaw("Horizontal") >0  && Input.GetButtonDown("Jump")) //wall jump from right
            {
               m_RigidBody2D.velocity = new Vector2(-runForce, jumpSpeed*.2f);
            }
            else if ( m_WalledLeft && Input.GetAxisRaw("Horizontal") <0  && Input.GetButtonDown("Jump")) //wall jump from left
            {
               m_RigidBody2D.velocity = new Vector2( runForce, jumpSpeed*.2f);
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

        float targetVelocityHorizontal = 0.0f;

        if (Input.GetButton("Dash"))
        {
            targetVelocityHorizontal = Mathf.Clamp(m_RigidBody2D.velocity.x, -dashSpeed, dashSpeed); //limit the speed
            m_RigidBody2D.velocity = new Vector2(targetVelocityHorizontal, m_RigidBody2D.velocity.y) ; //maintain the target velocity
        }
        else
        {
            
            if (Mathf.Abs(m_RigidBody2D.velocity.x) > 1.5f * runSpeed) //if high over regular limit, decrease speed gradually rather than instantly
            {
                m_RigidBody2D.AddForce(new Vector2(-2f * runForce * m_RigidBody2D.velocity.x / runSpeed, 0f));
            }
            else
            {
                targetVelocityHorizontal = Mathf.Clamp(m_RigidBody2D.velocity.x, -dashSpeed, dashSpeed); //limit speed
                m_RigidBody2D.velocity = new Vector2(targetVelocityHorizontal, m_RigidBody2D.velocity.y);//maintain the target velocity
            }
            
        }

        //booleans for whether player is gounded to on wall.
        m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
        m_WalledLeft = Physics2D.Linecast(transform.position, m_WallCheckLeft.position, m_WallLayer) ;
        m_WalledRight = Physics2D.Linecast(transform.position, m_WallCheckRight.position, m_WallLayer);
        
    }

}
