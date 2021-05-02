using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : EnemyProjectile
{
    [SerializeField] GameObject shadowPrefab;
    [SerializeField] float startSpeed;
    [SerializeField] float shadowYLocation;

    Rigidbody2D rb;
    Shadow myShadow;

    // Start is called before the first frame update
    void Start()
    {
        // create shadow and set its chicken as this one
        myShadow = Instantiate(shadowPrefab, new Vector2(transform.position.x, shadowYLocation), Quaternion.identity).GetComponent<Shadow>();
        myShadow.chicken = this;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * startSpeed;

        // in case it misses the player, destroy after a few seconds
        Destroy(gameObject, 5f);
    }

    void OnDestroy()
    {
        FindObjectOfType<ChickenAttack>().ChickenDespawned();
        Destroy(myShadow.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
