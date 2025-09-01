using System.Collections;
using UnityEngine;

public class EnemeyMovement : EntityMovement
{
    [SerializeField] private float _stoppingDistance;

    private Coroutine _moving;
    protected override void MoveToPosition(Vector2 target)

    {
        if (_moving != null)
        {
            StopCoroutine(_moving);
            _moving = null;
        }

        _moving = StartCoroutine(Moving(target));
    }

    private IEnumerator Moving(Vector2 target)
    {
        Vector2 offset = target - (Vector2)transform.position;

        while (offset.sqrMagnitude > _stoppingDistance * _stoppingDistance)
        {
            offset = target - (Vector2)transform.position;

            yield return null;
        }

        _moving = null;
    }
}
