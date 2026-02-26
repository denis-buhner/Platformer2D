using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Vector2> _targetsPositions;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private float _stoppingDistance = 0.1f;

    private Coroutine _selectingWayPoint;
    private int _currentWaypointIndex = 0;

    public event Action<float> Moving;

    public bool IsArrived { get; private set; } = false;

    private void OnEnable()
    {
        if (_targets == null)
            return;

        foreach (Transform target in _targets)
        {
            _targetsPositions.Add(target.position);
        }
    }

    public void StartPatrolling()
    {
        if (IsEnoughPlaces())
        {
            if (_selectingWayPoint == null)
            {
                _selectingWayPoint = StartCoroutine(SelectWayPoint());
            }
        }
    }

    public void StopPatrolling()
    {
        if(_selectingWayPoint == null)
            return;

        StopCoroutine(_selectingWayPoint);
        _selectingWayPoint = null;
    }

    private bool IsEnoughPlaces()
    {
        return _targetsPositions.Count > 0;
    }

    private bool IsCloseEnough(Vector3 currentWayPoint, Vector3 currentPosition)
    {
        return Mathf.Abs(currentPosition.x - currentWayPoint.x) <= _stoppingDistance;
    }

    private IEnumerator SelectWayPoint()
    {
        IsArrived = false;

        while (!IsCloseEnough(transform.position, _targetsPositions[_currentWaypointIndex]))
        {
            Vector2 direction = (_targetsPositions[_currentWaypointIndex] - (Vector2)transform.position).normalized;

            Moving?.Invoke(direction.x);
            Debug.DrawLine(transform.position, _targetsPositions[_currentWaypointIndex], Color.red);
            yield return null;
        }

        _currentWaypointIndex = ++_currentWaypointIndex % _targetsPositions.Count;
        IsArrived = true;
    }
}
