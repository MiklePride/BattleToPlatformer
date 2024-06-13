using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Entity Entity;

    private void OnEnable()
    {
        Entity.HealthChenged += OnHealthChenge;
    }

    private void OnDestroy()
    {
        Entity.HealthChenged -= OnHealthChenge;
    }

    protected abstract void OnHealthChenge(float health, float maxHealth);
}
