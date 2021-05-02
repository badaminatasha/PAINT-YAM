using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheddarAttack : Attack
{
    [SerializeField] GameObject cheesePrefab;
    [SerializeField] int numSlicesToThrowAtOnce;
    [SerializeField] int numThrows;

    // taken from Vector3.right
    [SerializeField] float maxLaunchRotation;
    [SerializeField] float minLaunchRotation;

    public override IEnumerator DoAttack()
    {

        for(int i = 0; i < numThrows; i++)
        {
            yield return new WaitUntil(() => attackStartAnimationEventTriggered);
            for (int j = 0; j < numSlicesToThrowAtOnce; j++)
            {
                Instantiate(cheesePrefab, transform.position + Vector3.left, Quaternion.Euler(Vector3.forward * Random.Range(minLaunchRotation, maxLaunchRotation)));
            }
            attackStartAnimationEventTriggered = false;
        }

        // the attack sequence turns it on, we turn it off
        animator.SetBool(animatorFlag, false);

        attackStartAnimationEventTriggered = false;
    }

    public void AnimationEventStartCheddarAttack()
    {
        attackStartAnimationEventTriggered = true;
    }
}
