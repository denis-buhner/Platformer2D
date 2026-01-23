using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _zPosition;

    private void LateUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector2 direction = Vector2.Lerp(transform.position, _player.transform.position, _speed*Time.deltaTime);
        transform.position = new Vector3(direction.x, direction.y, _zPosition);
    }
}
