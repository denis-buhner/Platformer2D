using System;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public event Action<EntityMovement> EnteredKillZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("вошел");

        if (collision.TryGetComponent<EntityMovement>(out var entity))
        {
            Debug.Log("вошел2");
            EnteredKillZone?.Invoke(entity);
        }
    }
}
