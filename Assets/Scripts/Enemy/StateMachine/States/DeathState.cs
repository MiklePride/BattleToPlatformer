using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class DeathState : State
{
    private CapsuleCollider2D _capsuleCollider;
    private float _delayBeforeDestroy = 3f;

    public event Action Died;

    private void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnEnable()
    {
        _capsuleCollider.enabled = false;
        Died?.Invoke();
        Destroy(gameObject, _delayBeforeDestroy);
    }
}
