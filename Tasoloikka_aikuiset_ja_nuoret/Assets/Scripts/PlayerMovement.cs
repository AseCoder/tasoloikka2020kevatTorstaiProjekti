using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 5f;
    private Rigidbody2D rb2D;
    private Animator anim;
    public CircleCollider2D myFeet;
    public int facing = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float flipX = Input.GetAxisRaw("Horizontal");

        rb2D.velocity = new Vector2(horizontalMovement * moveSpeed * Time.deltaTime, rb2D.velocity.y);

        if(rb2D.velocity.x != 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if (Input.GetButtonDown("Jump") && myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
        {
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if(flipX != 0)
        {
            FlipPlayer(flipX);
        }
    }

    public void FlipPlayer(float x)
    {
        transform.localScale = new Vector2(x, transform.localScale.y);
        facing = (int)x;
    }
}