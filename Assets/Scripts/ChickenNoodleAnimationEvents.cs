using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenNoodleAnimationEvents : MonoBehaviour
{
    ChickenAttack chickenAttack;
    LongNoodleAttack longNoodleAttack;

    // Start is called before the first frame update
    void Start()
    {
        chickenAttack = GetComponentInParent<ChickenAttack>();
        longNoodleAttack = GetComponentInParent<LongNoodleAttack>();
    }

    public void StartChickenAttack()
    {
        chickenAttack.AnimationEventStartChickenAttack();
    }

    public void StartLongNoodleAttack()
    {
        longNoodleAttack.AnimationEventStartLongNoodleAttack();
    }
}
