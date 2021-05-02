using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool crouching = false;

    [SerializeField] float groundSpeed;
    [SerializeField] float airSpeed;
    [SerializeField] float jumpSpeed;

    Rigidbody2D rb;
    Animator animator;
    Vector2 input;
    bool touchingGround;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        // Strafe
        // Only strafe if not crouching
        if (!crouching)
        {
            rb.velocity = new Vector2(input.x * (touchingGround ? groundSpeed : airSpeed), rb.velocity.y);
            animator.SetBool("walk", !Mathf.Approximately(rb.velocity.x, 0f));
            if (rb.velocity.x < 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (rb.velocity.x > 0f) transform.rotation = Quaternion.identity;
        }
        else rb.velocity = new Vector2(0f, rb.velocity.y);

        // Jump
        if (input.y > 0 && touchingGround)
        {
            rb.velocity += Vector2.up * jumpSpeed;
            touchingGround = false;
            animator.SetBool("jump", true);
        }
        // crouch
        else if (input.y < 0 && !crouching && touchingGround)
        {
            crouching = true;
            animator.SetBool("crouch", true);
        }
    }

    public void StopCrouching()
    {
        crouching = false;
        animator.SetBool("crouch", false);
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && !touchingGround)
        {
            touchingGround = true;
            animator.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            touchingGround = false;
    }
}