using System.Collections;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    [SerializeField] private float _idleTime = 0.1f;

    private Coroutine _idleCoroutine;

    public bool IsIdle { get; private set; } = false;

    public void StartIdle()
    {
        if (_idleCoroutine == null)
        {
            _idleCoroutine = StartCoroutine(PerformIdle());
        }
    }

    public void StopIdle()
    {
        StopCoroutine(_idleCoroutine);
        _idleCoroutine = null;
    }

    private IEnumerator PerformIdle()
    {
        IsIdle = true;

        yield return _idleTime;

        IsIdle = false;
    }
}
