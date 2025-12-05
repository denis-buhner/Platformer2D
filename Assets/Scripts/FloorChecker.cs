using System;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class FloorChecker : MonoBehaviour
{
    public event Action<bool> OnFloorStay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnFloorStay?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnFloorStay?.Invoke(false);
    }
}
