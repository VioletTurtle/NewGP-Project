using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    private Rigidbody rb;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.VelocityChange);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
       
        float moveHorizontal = Input.GetAxis("Horizontal");
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        //rb.AddForce(movement * speed);

        transform.position = transform.position + (movement * speed);


    }
}
