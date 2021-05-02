using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAttack : Attack
{
    [SerializeField] GameObject chickenPrefab;
    [SerializeField] int numChickenToSpawn;
    [SerializeField] float delayBetweenChickens;
    [SerializeField] Transform spawnPointLeftmost;
    [SerializeField] Transform spawnPointRightmost;

    float SpawnXBreadth { get { return spawnPointRightmost.position.x - spawnPointLeftmost.position.x; } }
    int numActiveChickens = 0;

    public override IEnumerator DoAttack()
    {
        yield return new WaitUntil(() => attackStartAnimationEventTriggered);

        // immediately turn off the animator flag for this attack to prevent triggering a second attack
        animator.SetBool(animatorFlag, false);

        numActiveChickens = 0;

        for(int i = 0; i < numChickenToSpawn; i++)
        {
            float xOffsetFromOrigin = (Random.Range(0, (float)numChickenToSpawn) / (numChickenToSpawn - 1)) * SpawnXBreadth;
            Instantiate(chickenPrefab, spawnPointLeftmost.position + Vector3.right * xOffsetFromOrigin, Quaternion.identity);
            numActiveChickens++;
            yield return new WaitForSeconds(delayBetweenChickens);
        }

        yield return new WaitUntil(() => numActiveChickens == 0);

        attackStartAnimationEventTriggered = false;
    }

    public void AnimationEventStartChickenAttack()
    {
        attackStartAnimationEventTriggered = true;
    }

    public void ChickenDespawned() { numActiveChickens--; }
}
