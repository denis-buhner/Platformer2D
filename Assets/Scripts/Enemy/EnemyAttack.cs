using UnityEngine;

public class EnemyAttack : Combat
{
    [SerializeField] private float _damage;

    public override void Attack(IDamageable damageable)
    {
        base.Attack(damageable);        
        damageable.TakeDamage(_damage);
    }
}
