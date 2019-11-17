using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private float timer;
    public float jumpDelay;
    private bool canJump;

    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        canJump = true;
        float degrees = 90;
        Vector3 to = new Vector3(degrees, 0, 0);

        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);

    }

    void OnCollisionStay()
    {

        isGrounded = true;


    }

   /* void Update()
    {
        jump();
        
        if (active)
            timer -= Time.deltaTime;    //Subtract the time since last frame from the timer.
        if (timer < 0)
            timer = 0;
        

        //CompleteAction(timer);
        
    } */

    void FixedUpdate()
    {
       
        float moveHorizontal = Input.GetAxis("Horizontal");
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        
        jump();
        

        if (Input.GetButton("PlayerMove"))
        {
            transform.position = transform.position + (movement * speed);

            turning(moveHorizontal);

            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

       
    }


    

    void turning(float h)
    {
        if (h < 0)
        {
            float degrees = -90;
            Vector3 to = new Vector3(0, degrees, 0);

            transform.eulerAngles = to;
        }
        else if(h > 0)
        {
            float degrees = 90;
            Vector3 to = new Vector3(0, degrees, 0);

            transform.eulerAngles = to;
        }
    }

    void Animating(float h)
    {
        
           
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f;
        
        // Tell the animator whether or not the player is walking.
        anim.SetBool("isWalking", walking);
        
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.VelocityChange);
            isGrounded = false;
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);

        }
    }
/*
    public void CompleteAction(float timer)
    {
        if (timer > 0)                  //If timer greater than 0, don't complete action
            return;

        active = false;                 //Set active to be false so timer does not start moving until after action is complete. Remove this if you want timer to restart right away.

        jump();

        timer = jumpDelay;

        active = true;
    }
    */
}
