using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativePhysicsWithRot : MonoBehaviour
{
    

    [Header("Movement")]
    public float hMovement;
    public float walkSpeed = 5.0f;
    public float frame;

    [Header("Rotation")]
    public float rMovement;
    public float rotationRate = 180.0f;

    [Header("Jump")]
    public float verticalVelocity;
    public float jumpForce = 15.0f;
    public float gravity = 9.81f;

    [Header("Is Grounded")]
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    // Start is called before the first frame update
    /*private void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        frame = Time.deltaTime;

        //----Move----//
        hMovement = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * hMovement * walkSpeed * frame);


        //----Rotation----//
        rMovement = Input.GetAxis("Vertical");
        transform.Rotate(0, rMovement * rotationRate * frame, 0);

       

        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, ground);

        if (isGrounded)
        {
            verticalVelocity = 0;
            transform.Translate(Vector3.forward * hMovement * walkSpeed * frame);
            transform.Rotate(0, rMovement * rotationRate * frame, 0);

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
                transform.Translate(0, verticalVelocity * frame, hMovement * walkSpeed * frame);
                transform.Rotate(0, rMovement * rotationRate * frame, 0);
            }

        }

        else
        {
            verticalVelocity -= (gravity * frame);
            transform.Translate(0, verticalVelocity * frame, hMovement * frame * walkSpeed);
        }

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            transform.Translate(-5 * hMovement * walkSpeed * frame, 6 * frame, -5 * hMovement * walkSpeed * frame);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.Translate(-5 * hMovement * walkSpeed * frame, 6 * frame, -5 * hMovement * walkSpeed * frame);
        }
    }

   
}
