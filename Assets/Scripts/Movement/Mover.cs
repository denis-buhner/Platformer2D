using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Flipper _flipper;

    private Rigidbody2D _rigidbody2D;
    private float _speed;
    private float _previousDirection;

    public void Initialize(Rigidbody2D rigidbody2D, float speed, Transform playerTransform)
    {
        _rigidbody2D = rigidbody2D;
        _speed = speed;

        _flipper.Initialize(playerTransform);
    }

    public void MoveInDirection(float directionX)
    {
        _rigidbody2D.linearVelocityX = directionX*_speed;

        if(Mathf.Sign(directionX) != Mathf.Sign(_previousDirection))
        {
            _flipper.Flip();
            _previousDirection = directionX;
        }
    }
}
