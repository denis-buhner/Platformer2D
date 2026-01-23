using UnityEngine;

[RequireComponent(typeof(FloorChecker))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private FloorChecker _floorChecker;

    private Rigidbody2D _rigidbody2D;
    private float _jumpSpeed;
    private float _collisionCount = 0;

    private void OnEnable()
    {
        _floorChecker.FloorStaying += SwitchFloorStaying;
    }

    private void OnDisable()
    {
        _floorChecker.FloorStaying -= SwitchFloorStaying;
    }

    public void Initialize(Rigidbody2D rigidbody2D, float jumpSpeed)
    {
        _jumpSpeed = jumpSpeed;
        _rigidbody2D = rigidbody2D;
    }

    public void Jump()
    {
        if (_collisionCount > 0)
        {
            _rigidbody2D.AddForceY(_jumpSpeed, ForceMode2D.Impulse);
        }

        Debug.Log(_collisionCount);
    }

    private void SwitchFloorStaying(bool isOnFloor)
    {
        _collisionCount = isOnFloor ? ++_collisionCount : --_collisionCount;
    }
}
