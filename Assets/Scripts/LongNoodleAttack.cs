using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoodleAttack : Attack
{
    [SerializeField] GameObject noodlePrefab;
    [SerializeField] int numNoodleClaps;
    [SerializeField] int numNoodlesToSpawnAtOnce;
    [SerializeField] float delayBetweenNoodles;
    [SerializeField] Transform spawnPointUppermost;
    [SerializeField] Transform spawnPointLowermost;

    // taken from Vector3.right
    [SerializeField] float maxLaunchRotation;
    [SerializeField] float minLaunchRotation;

    float SpawnYBreadth { get { return spawnPointUppermost.position.y - spawnPointLowermost.position.y; } }
    int numActiveNoodles = 0;

    public override IEnumerator DoAttack()
    {
        numActiveNoodles = 0;

        for(int i = 0; i < numNoodleClaps; i++)
        {
            yield return new WaitUntil(() => attackStartAnimationEventTriggered);
            // immediately turn off the animator flag for this attack to prevent triggering a second attack
            animator.SetBool(animatorFlag, false);

            attackStartAnimationEventTriggered = false;
            for (int j = 0; j < numNoodlesToSpawnAtOnce; j++)
            {
                float yOffsetFromOrigin = (i / (float)(numNoodleClaps - 1)) * SpawnYBreadth;
                Instantiate(noodlePrefab,
                            spawnPointLowermost.position + Vector3.up * yOffsetFromOrigin,
                            Quaternion.Euler(0f, 0f, Random.Range(minLaunchRotation, maxLaunchRotation)));
                numActiveNoodles++;
            }
        }

        yield return new WaitUntil(() => numActiveNoodles == 0);

        attackStartAnimationEventTriggered = false;
    }

    public void AnimationEventStartLongNoodleAttack()
    {
        attackStartAnimationEventTriggered = true;
    }

    public void NoodleDespawned() { numActiveNoodles--; }
}
