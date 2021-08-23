using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick js;

    public bool isAdroid = false;

    public float speed;
    public float jumpForce;

    public LayerMask ground;

    bool isGrounded = false;
    Vector2 movement;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float inputH = 0f;
        if(isAdroid)
        {
            inputH = js.Horizontal;
            if(js.Horizontal < -0.3f)
            {
                inputH = -1f;
            }
            else if(js.Horizontal > 0.3f)
            {
                inputH = 1f;
            }
            else
            {
                inputH = 0f;
            }
        
        }
        else
        {
            inputH = Input.GetAxisRaw("Horizontal");
        }

        movement = new Vector2(inputH * speed , rb.velocity.y);

        //flip
        if(inputH != 0)
        {
            transform.localScale = new Vector3(inputH , 1f , 1f);
            anim.Play("Base Layer.Run");
        }
        else
        {
            if(isGrounded)
            {
                anim.Play("Base Layer.Stand");
            }
        }

        //jump
        if(Input.GetButton("Jump"))
        {
            Jump();
        }   
    }

    public void Jump()
    {
        if(isGrounded)
        {
            Vector2 jump  =new Vector2(rb.velocity.x , jumpForce);
            rb.velocity = jump;
            anim.Play("Base Layer.Jump");
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement;
        isGrounded = Physics2D.OverlapCircle(transform.GetChild(1).position , 0.2f , ground);
    }
}
