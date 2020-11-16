using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header ("Movement")]
    public float hXMovement;
    public float hZMovement;
    public float walkSpeed;

    [Header("Jump")]
    public float verticalVelocity;
    public float jumpForce = 3f;
    public float gravity = 9.81f;

    [Header("Is Grounded")]
    public GameObject groundCheckObj;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    public float frame;
    float movement = 0.3f;
    

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
      
        frame = Time.deltaTime;

       //Jump Management
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;

            transform.position += new Vector3(0, jumpForce, 0);
        }
        else
        {
            verticalVelocity -= (gravity * frame);
        }


       //Movement
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-movement, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(movement, 0, 0);
        }

        //Hit Input
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<Player>().ActivateHitRoutine();
        }
    }
    
    //Colisión
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Ground>() != null)
        {
            isGrounded = true;
        }
    }
}
