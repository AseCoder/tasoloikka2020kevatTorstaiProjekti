using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb2D;
    bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            rb2D.velocity = new Vector2(moveSpeed*Time.deltaTime, 0f);
        }
        else
        {
            rb2D.velocity = new Vector2(-moveSpeed * Time.deltaTime, 0f);
        }
    }

    public bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb2D.velocity.x)), transform.localScale.y);
    }

}
