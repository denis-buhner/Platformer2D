using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EntityMovement : MonoBehaviour
{
    [SerializeField] private KillZone _killZone;
    [SerializeField] protected float walkingSpeed;
    [SerializeField] protected float runningSpeed;
    [SerializeField] protected float jumpingSpeed;

    protected virtual void OnEnable()
    {
        _killZone.EnteredKillZone += Die;
    }

    private void Update()
    {
        if(TryChooseMovement(out MovementMode movementMode))
        {
            if(movementMode == MovementMode.Walking)
            {
                WalkToPosition(GetTarget());
            }
            else if (movementMode == MovementMode.Running)
            {
                RunToPosition(GetTarget());
            }
            else if(movementMode == MovementMode.Jumping)
            {
                Jump();
            }
        }
    }

    private void OnDisable()
    {
        _killZone.EnteredKillZone -= Die;
    }

    protected abstract bool TryChooseMovement(out MovementMode movementMode);

    protected abstract Vector2 GetTarget();

    protected abstract void WalkToPosition(Vector2 target);

    protected abstract void RunToPosition(Vector2 target);

    protected abstract void Jump();

    protected enum MovementMode
    {
        Staying,
        Jumping,
        Walking,
        Running,
    }

    private void Die(EntityMovement entity)
    {
        if (entity == this)
        {
            Debug.Log("умирай");
            this.gameObject.SetActive(false);
        }
    }
}
