using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoodle : EnemyProjectile
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Random.Range(minSpeed, maxSpeed);

        // in case it misses the player, despawn after a few seconds
        Destroy(gameObject, 4f);
    }

    void OnDestroy()
    {
        FindObjectOfType<LongNoodleAttack>().NoodleDespawned();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
