using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Respawn : MonoBehaviour
{
    public float threshold = -20;


    void FixedUpdate()
    {
        if (transform.position.y < threshold)
            transform.position = new Vector3(-9.99f, 0.33f, 26.79f);
    }
}