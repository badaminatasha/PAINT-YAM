using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpoonParryListener : MonoBehaviour
{
    [SerializeField] float parrySpeed;

    Animator animator;
    IEnumerator spoonParryCoroutine = null;
    bool spoonParryAnimationDone = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnSpoonParry(InputValue value)
    {
        if (value.isPressed && spoonParryCoroutine == null)
        {
            spoonParryCoroutine = SpoonParryCoroutine();
            StartCoroutine(spoonParryCoroutine);
        }
    }

    IEnumerator SpoonParryCoroutine()
    {
        spoonParryAnimationDone = false;

        animator.SetBool("SpoonParry", true);

        yield return new WaitUntil(() => spoonParryAnimationDone);

        animator.SetBool("SpoonParry", false);

        spoonParryCoroutine = null;
    }

    public void FinishSpoonParryAnim()
    {
        spoonParryAnimationDone = true;
    }

    // TODO: put all enemy projectiles under a single abstract projectile class so that this game obj parameter can be replaced w projectile
    public void SpoonParryHit(GameObject projectile)
    {
        // parry the projectile by disabling its projectile script and changing its color, collision layer, and direction
        projectile.GetComponent<EnemyProjectile>().enabled = false;
        projectile.layer = LayerMask.NameToLayer("PlayerProjectile");
        projectile.GetComponent<Rigidbody2D>().velocity = (FindObjectOfType<Attack>().transform.position - projectile.transform.position).normalized * parrySpeed;
    }
}