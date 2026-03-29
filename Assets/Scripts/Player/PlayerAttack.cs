using UnityEngine;

public class PlayerAttack : Combat, IAttacker
{
    [SerializeField] private float _damage;
    public override void Attack(IDamageable damageable)
    {
        base.Attack(damageable);
        damageable.TakeDamage(_damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            if(!collision.TryGetComponent(out Player player))
            {
                if (CanAttack(collision.transform))
                {
                    Attack(damageable);
                }
            }
        }
    }
}
