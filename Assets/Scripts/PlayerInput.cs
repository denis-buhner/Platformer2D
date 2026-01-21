using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKeyCode;

    public event Action<float> SelectedHorizontalDirection;
    public event Action SelectedJump;

    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

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
