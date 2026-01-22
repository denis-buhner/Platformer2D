using UnityEngine;

[RequireComponent(typeof(Mover), typeof(WaypointSelector), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private WaypointSelector _waypointSelector;
    [SerializeField] private Mover _mover;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _movingDistance = 1f;

    private void OnEnable()
    {
        _waypointSelector.Initialize(transform, _movingDistance);
        _mover.Initialize(_rigidbody2D, _speed, transform);
        _waypointSelector.Moving += _mover.MoveInDirection;
    }

    private void OnDisable()
    {
        _waypointSelector.Moving -= _mover.MoveInDirection;
    }
}
