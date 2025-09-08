using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EntityMovement : MonoBehaviour
{
    [SerializeField] private KillZone _killZone;
    [SerializeField] protected float speed;

    protected virtual void OnEnable()
    {
        _killZone.EnteredKillZone += Die;
    }

    private void Update()
    {
        if (TryGetTarget(out Vector2 target))
        {
            MoveToPosition(target);
        }
    }

    private void OnDisable()
    {
        _killZone.EnteredKillZone -= Die;
    }

    protected abstract bool TryGetTarget(out Vector2 target);

    protected abstract void MoveToPosition(Vector2 target);

    private void Die(EntityMovement entity)
    {
        if(entity == this)
        {
            Debug.Log("умирай");
            this.gameObject.SetActive(false);
        }
    }
}
