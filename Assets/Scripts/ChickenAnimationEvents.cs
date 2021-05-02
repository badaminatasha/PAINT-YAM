using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAnimationEvents : MonoBehaviour
{
    Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        chicken = GetComponentInParent<Chicken>();
    }

    public void ChickenImpact()
    {
        chicken.DestroyChicken();
    }
}
