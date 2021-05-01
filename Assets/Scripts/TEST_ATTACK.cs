using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ATTACK : Attack
{
    public override IEnumerator DoAttack()
    {
        Debug.Log("TEST ATTACK START");
        yield return new WaitForSeconds(delayBeforeStart);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
