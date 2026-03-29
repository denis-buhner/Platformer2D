using System;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrol), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private EnemyPatrol _patroller;
    [SerializeField] private Mover _mover;
    [SerializeField] private EnemyChasing _chasing;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private EnemyStateMachine _stateMachine;
    [SerializeField] private HealthHandler _healthHandler;

    private void OnEnable()
    {
        _mover.Initialize(_rigidbody2D, _speed, transform);
        _patroller.Moving += _mover.MoveInDirection;
        _chasing.Moving += _mover.MoveInDirection;

        _stateMachine.StartStateMachine();
    }

    private void OnDisable()
    {
        _stateMachine.StopStateMachine();

        _patroller.Moving -= _mover.MoveInDirection;
        _chasing.Moving -= _mover.MoveInDirection;
    }
}
