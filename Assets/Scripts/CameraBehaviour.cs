using System.Collections;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _zPosition;

    private Coroutine _moveToPlayerCoroutine;

    private void OnEnable()
    {
        if(_moveToPlayerCoroutine == null)
        {
            _moveToPlayerCoroutine = StartCoroutine(MoveToPlayer());
        }
    }

    private void OnDisable()
    {
        if (_moveToPlayerCoroutine != null)
        {
            StopCoroutine( _moveToPlayerCoroutine );
            _moveToPlayerCoroutine = null;
        }
    }

    private IEnumerator MoveToPlayer()
    {
        while(gameObject.activeSelf)
        {
            yield return null;

            Vector2 direction = Vector2.Lerp(transform.position, _player.transform.position, _speed*Time.deltaTime);
            transform.position = new Vector3(direction.x, direction.y, _zPosition);
        }
    }
}
