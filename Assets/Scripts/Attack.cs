using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public string animatorFlag;

    protected bool attackStartAnimationEventTriggered = false;
    protected Animator animator;

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public abstract IEnumerator DoAttack();
}
