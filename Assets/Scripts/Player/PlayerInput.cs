using System;
using UnityEngine;  

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKeyCode;

    public event Action<float> SelectedHorizontalDirection;
    public event Action SelectedJump;

    private string _horizontalAxis = "Horizontal";

    private void Update()
    {
        float horizontalInput = Input.GetAxis(_horizontalAxis);

        if (horizontalInput != 0)
        {
            SelectedHorizontalDirection?.Invoke(horizontalInput);
        }

        if (Input.GetKeyDown(_jumpKeyCode))
        {
            SelectedJump?.Invoke();
        }
    }
}
