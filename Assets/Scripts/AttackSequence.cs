using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSequence : MonoBehaviour
{
    [SerializeField] List<Attack> attackSequence = new List<Attack>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        while (true)
        {
            foreach (Attack attack in attackSequence)
            {
                yield return attack.DoAttack();
            }
        }
    }
}
