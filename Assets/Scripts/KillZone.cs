using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KillZone : MonoBehaviour
{
    public event Action<EntityMovement> EnteredKillZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EntityMovement>(out var entity))
        {
            EnteredKillZone?.Invoke(entity);
        }
    }
}
