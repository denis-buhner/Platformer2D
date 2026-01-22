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
        float HorizontalInput = Input.GetAxis(_horizontalAxis);

        if (HorizontalInput != 0)
        {
            SelectedHorizontalDirection?.Invoke(HorizontalInput);
        }

        if (Input.GetKeyDown(_jumpKeyCode))
        {
            SelectedJump?.Invoke();
        }
    }
}
