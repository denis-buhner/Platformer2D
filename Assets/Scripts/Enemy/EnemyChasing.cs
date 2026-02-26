using System;
using System.Collections;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    [SerializeField] private float _stoppingDistance;

    private Transform _targetTransform;
    private Coroutine _chasingCoroutine;

    public event Action<float> Moving;

    public bool IsArrived { get; private set; } = false;

    public void StartChasing(Transform target)
    {
        if(_chasingCoroutine == null && target != null)
        {
            _targetTransform = target;
            _chasingCoroutine = StartCoroutine(Chasing());
        }
    }

    public void StopChasing()
    {
        if (_chasingCoroutine != null)
        {
            StopCoroutine(_chasingCoroutine);
            _chasingCoroutine = null;
            _targetTransform = null;
        }
    }

    private bool IsCloseEnough(Vector2 target, Vector2 currentPosition)
    {
        return Vector2.SqrMagnitude(currentPosition - target) <= _stoppingDistance * _stoppingDistance;
    }

    public IEnumerator Chasing()
    {
        IsArrived = false;

        while (!IsCloseEnough(transform.position, _targetTransform.position))
        {
            Vector2 targetPosition = (Vector2)_targetTransform.position;
            Vector2 enemyPosition = (Vector2)transform.position;
            Vector2 direction = (targetPosition - enemyPosition).normalized;

            Debug.DrawLine(transform.position, _targetTransform.position, Color.yellow);
            Moving?.Invoke(direction.x);

            yield return null;
        }

        IsArrived = true;
    }
}
