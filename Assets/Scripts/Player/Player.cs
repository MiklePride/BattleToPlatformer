using UnityEngine;

public class Player : Entity
{
    [SerializeField] private LootCollisionHandler _collisionHandler;

    private void OnEnable()
    {
        _collisionHandler.MedicalKitIsRaised += OnHeal; 
    }

    private void OnDestroy()
    {
        _collisionHandler.MedicalKitIsRaised -= OnHeal;
    }

    private void OnHeal(MedicalKit medicalKit)
    {
        ChengeHealth(Mathf.Abs(medicalKit.HealPoint));
        Destroy(medicalKit.gameObject);
    }
}