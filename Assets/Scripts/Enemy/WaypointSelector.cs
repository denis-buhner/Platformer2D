using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WaypointSelector : MonoBehaviour
{
    [SerializeField] private List<Vector2> _targetsPositions;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private float _stoppingDistance = 0.1f;
    [SerializeField] private float _stopDelay = 1;

    public event Action<float> Moving;

    private Coroutine _selectWayPoint;
    private float _movingDistance;
    private Transform _enemyTransform;

    public void Initialize(Transform transform, float movingDistance)
    {
        _enemyTransform = transform;
        _movingDistance = movingDistance;

        if (TryGetPlaces())
        {
            if (_selectWayPoint == null)
            {
                _selectWayPoint = StartCoroutine(SelectWayPoint());
            }
        }
    }

    private void OnDisable()
    {
        if (_selectWayPoint != null)
        {
            StopCoroutine(_selectWayPoint);
            _selectWayPoint = null;
        }
    }

    private bool TryGetPlaces()
    {
        if (_targets == null)
            return false;

        foreach(Transform target in _targets)
        {
            _targetsPositions.Add(target.position);
        }

        return _targetsPositions.Count > 0;
    }

    private bool IsCloseEnough(Vector3 currentWayPoint, Vector3 currentPosition)
    {
        return Mathf.Abs(currentPosition.x - currentWayPoint.x) <= _stoppingDistance;
    }

    private IEnumerator SelectWayPoint()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_stopDelay);

        int currentWaypointIndex = 0;

        while (isActiveAndEnabled)
        {

            while (!IsCloseEnough(_enemyTransform.position, _targetsPositions[currentWaypointIndex]))
            {
                Vector2 direction = (_targetsPositions[currentWaypointIndex] - (Vector2)_enemyTransform.position).normalized;

                Moving?.Invoke(direction.x);
                Debug.DrawLine(_enemyTransform.position, _targetsPositions[currentWaypointIndex], Color.red);
                yield return null;
            }

            currentWaypointIndex = ++currentWaypointIndex % _targetsPositions.Count;

            yield return waitForSeconds;
        }
    }
}
