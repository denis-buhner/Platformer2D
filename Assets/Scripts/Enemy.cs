using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Transform _wayPoints;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _stopDelay;
    [SerializeField] private float _speed;
    [SerializeField] private List<Vector2> _targetsPositions;

    private Coroutine _move;

    private void OnEnable()
    {
        if (TryGetPlaces())
        {
            if (_move == null)
            {
                _move = StartCoroutine(Move());
            }
        }
    }

    private void OnDisable()
    {
        if (_move != null)
        {
            StopCoroutine(_move);
            _move = null;
        }
    }

    [ContextMenu("Refresh Waypoints")]
    private bool TryGetPlaces()
    {
        int childCount = _wayPoints.childCount;
        if (_wayPoints == null || childCount == 0)
            return false;

        for (int i = 0; i < childCount; i++)
            _targetsPositions.Add(_wayPoints.GetChild(i).position);

        return _targetsPositions.Count > 0;
    }

    private bool IsCloseEnough(Vector3 currentWayPoint, Vector3 currentPosition)
    {
        return (currentWayPoint - currentPosition).sqrMagnitude <= _stoppingDistance * _stoppingDistance;
    }

    private IEnumerator Move()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_stopDelay);

        int currentWaypointIndex = 0;

        while (isActiveAndEnabled)
        {

            while (!IsCloseEnough(transform.position, _targetsPositions[currentWaypointIndex]))
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetsPositions[currentWaypointIndex], _speed * Time.deltaTime);

                yield return null;
            }

            currentWaypointIndex = ++currentWaypointIndex % _targetsPositions.Count;

            yield return waitForSeconds;
        }
    }
}
