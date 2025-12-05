using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(FloorChecker))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private FloorChecker _floorChecker;
    [SerializeField] private KeyCode _jumpKeyCode;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    private bool _isOnFloor;

    private void OnEnable()
    {
        _floorChecker.OnFloorStay += SwitchFloorStaying;
    }

    private void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (HorizontalInput != 0)
        {
            if(Mathf.Sign(HorizontalInput) != Mathf.Sign(transform.localScale.x))
            {
                FlipSprite();
            }

            MoveInDirection(HorizontalInput * _speed);
        }

        if (Input.GetKeyDown(_jumpKeyCode))
        {
            if (_isOnFloor)
            {
                Jump();
            }
        }
    }

    private void OnDisable()
    {
        _floorChecker.OnFloorStay -= SwitchFloorStaying;
    }

    private void MoveInDirection(float directionX)
    {
        _rigidbody2D.linearVelocityX = directionX;
        
    }

    private void Jump()
    {
        _rigidbody2D.AddForceY(_jumpSpeed, ForceMode2D.Impulse);
    }

    private void SwitchFloorStaying(bool isOnFloor)
    {
        _isOnFloor = isOnFloor;
    }

    private void FlipSprite()
    {
        Vector3 previousLocalScale = transform.localScale;
        float flipCoefficient = -1f;
        transform.localScale = new Vector3(previousLocalScale.x * flipCoefficient, previousLocalScale.y, previousLocalScale.z);
    }
}
