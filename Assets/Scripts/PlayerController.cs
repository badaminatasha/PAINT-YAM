using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    Rigidbody2D rb;
    Vector2 input;
    bool touchingGround;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Strafe
        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);

        // Jump
        if (input.y > 0 && touchingGround)
        {
            rb.velocity += Vector2.up * jumpSpeed;
            touchingGround = false;
        }
        else if (input.y < 0)
        {
            // crouch nonsense
        }
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        touchingGround = collision.gameObject.CompareTag("ground");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingGround = collision.gameObject.CompareTag("ground");
    }
}