using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpoonParry : MonoBehaviour
{
    [Serializable]
    public class OnParryEvent : UnityEvent<GameObject> { }

    [SerializeField] OnParryEvent onParry;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onParry?.Invoke(collision.gameObject);
    }
}