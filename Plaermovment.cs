using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Plaermovment : MonoBehaviour
{
//necessary for animations and physics
private Rigidbody2D rb2D;
private Animator myAnimator;

    private bool facingRight = true; 
//variables to play with
public float speed = 2.0f;
public float horizMovment;

private void Start()
    {
    //define the gameobjects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }


    // handles the input for physics
    private void Update()
    {
        //check dirction given by player
        horizMovment = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
        {
            //move the charactor left and right
            rb2D.velocity = new Vector2(horizMovment*speed, rb2D.velocity.y);
        Flip(horizMovment);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovment));
        }
    //flipping function
    private void Flip (float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal >0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
