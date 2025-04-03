using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowndSensor : MonoBehaviour
{
    public bool isGrounded;
    public Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {   
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
        }   
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
