using UnityEngine;

public interface IAttacker
{

    void Attack(IDamageable damageable);

    bool CanAttack(Transform transform);
}
