using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    private Rigidbody rb;
    private Animator anim;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
        float degrees = 90;
        Vector3 to = new Vector3(degrees, 0, 0);

        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);

    }

    void OnCollisionStay()
    {

        isGrounded = true;


    }

    void Update()
    {


        if (Input.GetKeyDown("space") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
            
        }
    }

    void FixedUpdate()
    {
       
        float moveHorizontal = Input.GetAxis("Horizontal");
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        

        if(Input.GetButton("PlayerMove"))
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
}
