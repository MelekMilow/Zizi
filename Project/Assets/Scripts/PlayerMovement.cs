using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 14f;

    private enum MoevementState { nm,rn,jumping,falling};
    


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
      UpdateAnimationUpdate();
 
    }
    private void UpdateAnimationUpdate()
    {
        MoevementState state;
        if (dirX > 0f)
        {
            state = MoevementState.rn;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MoevementState.rn;
            sprite.flipX = true;
        }
        else
        {
            state = MoevementState.nm;
        }

        if (rb.velocity.y > .1f)
        {
            state = MoevementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MoevementState.falling;
        }




        anim.SetInteger("state", (int)state);
    }
}
