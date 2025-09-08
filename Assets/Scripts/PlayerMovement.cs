using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : EntityMovement
{
    [SerializeField] private KeyCode _moveRight;
    [SerializeField] private KeyCode _moveLeft;
    [SerializeField] private KeyCode _moveDown;
    [SerializeField] private KeyCode _jump;
    [SerializeField] private Legs _legs;

    private Dictionary<KeyCode, Vector2> _directionByKey;
    private Rigidbody2D _rigidbody;

    protected override void OnEnable()
    {
        base.OnEnable();

        _rigidbody = GetComponent<Rigidbody2D>();

        _directionByKey = new Dictionary<KeyCode, Vector2>()
        {
            { _moveRight, Vector2.right },
            {_moveLeft, Vector2.left},
            {_moveDown, Vector2.down},
            {_jump, Vector2.up},
        };
    }

    protected override bool TryGetTarget(out Vector2 targetPosition)
    {
        targetPosition = Vector2.zero;
        bool isKeyDown = false;

        foreach (var key in _directionByKey.Keys)
        {
            if(Input.GetKey(key))
            {
                if (key == _jump)
                {
                    if (_legs.IsGrounded)
                    {
                        targetPosition += _directionByKey[key];
                    }
                }
                else
                {
                    targetPosition += _directionByKey[key];
                }

                isKeyDown = true;
            }
        }

        return isKeyDown;
    }

    protected override void MoveToPosition(Vector2 targetPosition)
    {
        _rigidbody.linearVelocity = targetPosition*speed;
    }
}
