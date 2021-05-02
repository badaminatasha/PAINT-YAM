using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSlice : MonoBehaviour
{
    [SerializeField] float maxReturningSpeed;
    [SerializeField] float startSpeed;
    [SerializeField] float angularSpeed;
    [SerializeField] float timeUntilStopTrackingPlayer;

    Rigidbody2D rb;
    Transform playerTransform;
    Vector2 targetPosition;
    float startTime;

    Vector2 acceleration = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = startSpeed * transform.right;
        rb.angularVelocity = angularSpeed;
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        targetPosition = playerTransform.position;
        startTime = Time.time;

        // in case it misses the player, despawn after a few seconds
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        // alternatively, set a bool when we get within a certain distance of the player, and then stop tracking them and just use that position
        if (Time.time < startTime + timeUntilStopTrackingPlayer)
            targetPosition = playerTransform.position;
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.SmoothDamp(rb.velocity,
                                         (targetPosition - (Vector2)transform.position).normalized * maxReturningSpeed,
                                         ref acceleration,
                                         Mathf.Max(startTime + timeUntilStopTrackingPlayer - Time.time, 0f));
        //if (Time.time >= startTime + timeUntilStopTrackingPlayer)
        //    rb.velocity = (targetPosition-(Vector2)transform.position).normalized * maxReturningSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
