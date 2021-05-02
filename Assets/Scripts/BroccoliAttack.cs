using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroccoliAttack : Attack
{
    #region VARIABLES

    [SerializeField] GameObject broccoliPrefab;
    [SerializeField] int numBroccoliToSpawn;
    [SerializeField] float delayBetweenBroccolis;
    [SerializeField] Transform spawnPointUppermost;
    [SerializeField] Transform spawnPointLowermost;

    float SpawnYBreadth { get { return spawnPointUppermost.position.y - spawnPointLowermost.position.y; } }
    int numActiveBroccolis = 0;

    #endregion

    public override IEnumerator DoAttack()
    {
        yield return new WaitUntil(() => attackStartAnimationEventTriggered);

        // immediately turn off the animator flag for this attack to prevent triggering a second attack
        animator.SetBool(animatorFlag, false);

        numActiveBroccolis = 0;

        for(int i = 0; i < numBroccoliToSpawn; i++)
        {
            float yOffsetFromOrigin = (i / (float)(numBroccoliToSpawn - 1)) * SpawnYBreadth;
            Instantiate(broccoliPrefab, spawnPointLowermost.position + Vector3.up * yOffsetFromOrigin, Quaternion.identity);
            numActiveBroccolis++;
            yield return new WaitForSeconds(delayBetweenBroccolis);
        }

        yield return new WaitUntil(() => numActiveBroccolis == 0);

        attackStartAnimationEventTriggered = false;
    }

    public void AnimationEventStartBroccoliAttack()
    {
        attackStartAnimationEventTriggered = true;
    }

    public void BroccoliDespawned() { numActiveBroccolis--; }
}
