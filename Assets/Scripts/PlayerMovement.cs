using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : EntityMovement
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Legs _legs;
    [SerializeField] private KeyCode _moveRightKey;
    [SerializeField] private KeyCode _moveLeftKey;
    [SerializeField] private KeyCode _jumpKey;
    protected override bool TryChooseMovement(out MovementMode movementMode)
    {
        movementMode = MovementMode.Staying;

        if (Input.GetKeyDown(_jumpKey))
        {
            if (_legs.IsGrounded)
            {
                movementMode = MovementMode.Jumping;
                return true;
            }
        }

        if (Input.GetKey(_moveRightKey) || Input.GetKey(_moveLeftKey))
        {
            if (_rigidbody.linearVelocity.sqrMagnitude < runningSpeed*runningSpeed)
            {
                movementMode = MovementMode.Walking;
                return true;
            }
            else
            {
                movementMode = MovementMode.Running;
                return true;
            }
        } 

        return false;
    }

    protected override Vector2 GetTarget()
    {
        Vector2 targetPosition = Vector2.zero;

        if (Input.GetKey(_moveLeftKey))
        {
            targetPosition += Vector2.left;
        }

        if (Input.GetKey(_moveRightKey))
        {
            targetPosition += Vector2.right;
        }
        return targetPosition;
    }

    protected override void WalkToPosition(Vector2 target)
    {
        _rigidbody.linearVelocity = new Vector2(target.x * walkingSpeed, _rigidbody.linearVelocity.y);
    }

    protected override void RunToPosition(Vector2 target)
    {
        _rigidbody.linearVelocity = new Vector2(target.x * runningSpeed, _rigidbody.linearVelocity.y);
    }

    protected override void Jump()
    {
        _rigidbody.AddForce(Vector2.up * jumpingSpeed, ForceMode2D.Impulse);
    }
}
