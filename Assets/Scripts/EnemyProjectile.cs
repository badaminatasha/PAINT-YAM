using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyProjectile : MonoBehaviour {
    [SerializeField] float damageOnHit;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Health otherHealth = collision.gameObject.GetComponent<Health>();
        if (otherHealth)
        {
            otherHealth.DecreaseHealthBy(damageOnHit);
        }
    }
}
