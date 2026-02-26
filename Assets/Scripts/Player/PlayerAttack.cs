using UnityEngine;

public class PlayerAttack : Combat, IAttackable
{
    [SerializeField] private float _damage;
    public void Attack(IDamageable damageable)
    {
        base.Attack(damageable);
        damageable.TakeDamage(_damage);
        Debug.Log("происходит атака");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("кто-то есть");
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("его можно атаковать");
            if(!collision.TryGetComponent(out Player player))
            {
                Debug.Log("Он не игрок");
                if (CanAttack(collision.transform))
                {
                    Debug.Log("будем атаковать его");
                    Attack(damageable);
                }
            }
        }
    }
}
