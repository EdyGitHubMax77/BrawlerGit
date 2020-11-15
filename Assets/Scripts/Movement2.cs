using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [Header("Movement")]
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
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isGrounded = false;

            transform.position += new Vector3(0, jumpForce, 0);
        }
        else
        {
            verticalVelocity -= (gravity * frame);
        }


        //LaterMovement

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movement, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movement, 0, 0);
        }

        //Hit Input
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Player>().ActivateHitRoutine();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            isGrounded = true;
        }
    }
}
