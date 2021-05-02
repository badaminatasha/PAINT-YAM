using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broccoli : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float yOffsetMax;
    [SerializeField] float yOffsetMin;
    [SerializeField] float verticalSpeed;

    Rigidbody2D rb;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startY = transform.position.y;
        // go up first
        rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector2.left * force);
        if (transform.position.y >= startY + yOffsetMax)
            rb.velocity = new Vector2(rb.velocity.x, -verticalSpeed);
        else if (transform.position.y <= startY + yOffsetMin)
            rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);
    }

    void Despawn()
    {
        FindObjectOfType<BroccoliAttack>().BroccoliDespawned();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Despawn();
    }

    private void OnBecameInvisible()
    {
        Despawn();
    }
}
