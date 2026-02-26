using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput), typeof(Jumper))]
[RequireComponent(typeof(Mover))]
public class Player : MonoBehaviour, ITargetable, IHealth
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _mover;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _health;

    public event Action IsDead;

    private void OnEnable()
    {
        _jumper.Initialize(_rigidbody2D, _jumpSpeed);
        _mover.Initialize(_rigidbody2D, _speed, transform);

        _playerInput.SelectedJump += _jumper.Jump;
        _playerInput.SelectedHorizontalDirection += _mover.MoveInDirection;
    }

    private void OnDisable()
    {
        _playerInput.SelectedJump -= _jumper.Jump;
        _playerInput.SelectedHorizontalDirection -= _mover.MoveInDirection;
    }

    public void TakeDamage(float damage)
    {
        if(damage > 0)
        {
            _health -= damage;
        }

        if (_health <= 0)
        {
            IsDead?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
