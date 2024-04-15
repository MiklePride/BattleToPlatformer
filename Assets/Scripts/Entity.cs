using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField, Min(1)] protected float MaxHealth = 10;

    protected float Health;

    public event Action DamageIsDone;

    public bool IsDeath {  get; private set; }

    private void Start()
    {
        Health = MaxHealth;
    }

    protected void ChengeHealth(float health)
    {
        Health = Mathf.Clamp(Health + health, 0, MaxHealth);

        if (Health == 0)
            IsDeath = true;
    }

    public void TakeDamage(float damage)
    {
        ChengeHealth(-Mathf.Abs(damage));
        DamageIsDone?.Invoke();
    }
}
