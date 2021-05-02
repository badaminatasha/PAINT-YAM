using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamenAnimationController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAttackOne()
    {
        animator.SetInteger("State", 1);
    }

    public void endAttackOne()
    {
        animator.SetInteger("State", 0);
    }

    public void startAttackTwo()
    {
        animator.SetInteger("State", 2);
    }

    public void endAttackTwo()
    {
        animator.SetInteger("State", 3);
    }

    public void AttackOneForTime(float time)
    {
        StartCoroutine(AttackForTime(1, 0, time));
    }

    public void AttackTwoForTime(float time)
    {
        StartCoroutine(AttackForTime(2, 3, time));
    }


    IEnumerator AttackForTime(int startState, int endState, float time)
    {
        animator.SetInteger("State", startState);

        float elapsedTime = 0;

        while (time >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        animator.SetInteger("State", endState);
    }
}
