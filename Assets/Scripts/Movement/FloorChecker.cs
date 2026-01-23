using System;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class FloorChecker : MonoBehaviour
{
    public event Action<bool> FloorStaying;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FloorStaying?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FloorStaying?.Invoke(false);
    }
}
