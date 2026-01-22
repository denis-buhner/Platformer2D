using UnityEngine;

[RequireComponent(typeof(FloorChecker))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private FloorChecker floorChecker;
    private Rigidbody2D _rigidbody2D;
    private float _jumpSpeed;
    private bool _isOnFloor;

    private void OnEnable()
    {
        floorChecker.OnFloorStay += SwitchFloorStaying;
    }

    private void OnDisable()
    {
        floorChecker.OnFloorStay -= SwitchFloorStaying;
    }

    public void Initialize(Rigidbody2D rigidbody2D, float jumpSpeed)
    {
        _jumpSpeed = jumpSpeed;
        _rigidbody2D = rigidbody2D;
    }

    public void Jump()
    {
        if (_isOnFloor)
        {
            _rigidbody2D.AddForceY(_jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void SwitchFloorStaying(bool isOnFloor)
    {
        _isOnFloor = isOnFloor;
    }
}
