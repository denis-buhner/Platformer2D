using UnityEngine;

public class PlayerMovement : EntityMovement
{
    [SerializeField] private KeyCode _moveRight;
    [SerializeField] private KeyCode _moveLeft;
    [SerializeField] private KeyCode _moveDown;
    [SerializeField] private KeyCode _jump;

    protected override void SetPosition()
    {
        base.SetPosition();

        Vector2 direction = Vector2.zero;

        if (Input.GetKey(_moveRight))
            direction += Vector2.right;

        if (Input.GetKey(_moveLeft))
            direction += Vector2.left;

        if (Input.GetKey(_moveDown))
            direction += Vector2.down;

        if (Input.GetKey(_jump))
            direction += Vector2.up;

        MoveToPosition((Vector2)transform.position + direction);
    }
}
