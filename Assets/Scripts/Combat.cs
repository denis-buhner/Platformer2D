using UnityEngine;
public class Combat : MonoBehaviour, IAttacker
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _coolDown;

    private float _nextCooldownOverTime;

    public virtual void Attack(IDamageable damageable)
    {
        SetCooldown();
    }

    public virtual bool CanAttack(Transform targetTransform)
    {
        if(targetTransform == null)
            return false;

        return IsCloseEnough(targetTransform) && IsCooldownOver();
    }

    private bool IsCloseEnough(Transform targetTransform)
    {
        return Vector2.SqrMagnitude((Vector2)transform.position - (Vector2)targetTransform.position) <= _attackDistance * _attackDistance;
    }

    private void SetCooldown()
        => _nextCooldownOverTime = Time.time + _coolDown;

    private bool IsCooldownOver()
        => Time.time > _nextCooldownOverTime;

}
