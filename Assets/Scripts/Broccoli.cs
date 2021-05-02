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

        // in case it misses the player, destroy after a few seconds
        Destroy(gameObject, 3f);
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector2.left * force);
        if (transform.position.y >= startY + yOffsetMax)
            rb.velocity = new Vector2(rb.velocity.x, -verticalSpeed);
        else if (transform.position.y <= startY + yOffsetMin)
            rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);
    }

    void OnDestroy()
    {
        FindObjectOfType<BroccoliAttack>().BroccoliDespawned();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
