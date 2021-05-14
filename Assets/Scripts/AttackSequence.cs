using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackSequence : MonoBehaviour
{
    List<Attack> attackSequence = new List<Attack>();
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        attackSequence = GetComponents<Attack>().ToList();
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        while (true)
        {
            foreach (Attack attack in attackSequence)
            {
                animator.SetBool(attack.animatorFlag, true);
                yield return attack.DoAttack();
            }
        }
    }
}
