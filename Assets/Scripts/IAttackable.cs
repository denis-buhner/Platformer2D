using UnityEngine;

public interface IAttackable
{

    void Attack(IDamageable damageable);

    bool CanAttack(Transform transform);
}
