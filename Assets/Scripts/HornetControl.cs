using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetControl : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private Animator _animator;
    private GrowndSensor _growndSensor;
    public float hornetSpeed = 4.5f;
    private float inputHorizontal;
    public float jumpForce = 10;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _growndSensor = GetComponentInChildren<GrowndSensor>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        Movement();
        
        if(Input.GetButtonDown("Jump") && _growndSensor.isGrounded == true)
        {
            Jump();
        }

        _animator.SetBool("IsJumping", !_growndSensor.isGrounded);
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(inputHorizontal * hornetSpeed, _rigidBody.velocity.y);
    }

    void Movement()
    {
        if(inputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if(inputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
