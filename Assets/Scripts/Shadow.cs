using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public Chicken chicken;
    
    [SerializeField] float startAlpha;
    [SerializeField] float endAlpha;

    SpriteRenderer sr;
    float startDistanceToChicken;

    // Start is called before the first frame update
    void Start()
    {
        startDistanceToChicken = Vector2.Distance(chicken.transform.position, transform.position);

        sr = GetComponentInChildren<SpriteRenderer>();
        Color c = sr.color;
        c.a = startAlpha;
    }

    // Update is called once per frame
    void Update()
    {
        Color c = sr.color;
        c.a = startAlpha + (endAlpha - startAlpha) * (1 - Vector2.Distance(chicken.transform.position, transform.position) / startDistanceToChicken);
        sr.color = c;
    }
}
